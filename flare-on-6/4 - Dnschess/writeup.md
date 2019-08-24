# Flare-on CTF 2019

## 4 - DNSChess

### Challenge text:

Some suspicious network traffic led us to this unauthorized chess program running on an Ubuntu desktop. This appears to be the work of cyberspace computer hackers. You'll need to make the right moves to solve this one. Good luck!

### Provided Files:

- capture.pcap (Packet Capture)
- ChessAI.so (library file)
- ChessUI (binary)
- Message.txt

### Tooling:

To view and analyze the packet capture, I used Wireshark. To decompile and analyze the binary, I used Ghidra. Finally, I used Excel to make a quick decoder.

### Solving the challenge:

First, I ran the executable which brought up a GUI. The GUI consists of a menu bar with two options (*File > New Game* and *File > Quit*), a chess board in which I am the white player and pieces can be dragged to move, and a chat log, with the initial message from **DeepFLARE** (apparently my opponent) 

> **DeepFLARE**: Finally, a worthy opponent. Let us begin.

After playing around with it for a while, I found that making any move will result in **DeepFLARE** resigning the game. I suspect there is a specific move to result in the opponent not resigning and that reversing the binary and analyzing the packet capture will lead to this sequence. 

Next, I openned up the .pcap in Wireshark. The capture consists of 80 DNS packets between IP addresses `192.168.122.1` and `192.168.122.29`. Each packet consists of a request and response pair that look similar to this:

```
1	0.000000	192.168.122.1	192.168.122.29	DNS	122	Standard query 0xabfd A rook-c3-c6.game-of-thrones.flare-on.com OPT
2	0.001078	192.168.122.29	192.168.122.1	DNS	188	Standard query response 0xabfd A rook-c3-c6.game-of-thrones.flare-on.com A 127.150.96.223 NS ns1.game-of-thrones.flare-on.com A 127.0.0.1 OPT
```

Notice that the domain name trying to be resolved looks like a move in chess? The packets seems to be in reverse order as the first packet is an illegal move, but packet 79 is a legal move. However, doing that move (pawn d2 to d4) still causes the program to resign (that would've been too easy... but I suspect that these moves will play a role in the solution). So, I need to reverse the binary and take a look at the source.

Opening the binary and library file in Ghidra, I noticed that the library file had a function called `getNextMove()`. I figure that the secret to this solution lies in the fact that the AI continually resigns after every move, so I took a look inside there. The next thing I noticed was that `getNextMove()` uses the function `gethostbyname()` which, in C, is used to resolve the IP address of a domain name. Putting two and two together: the trace was a whole bunch of DNS requests and now, here is this executable also making a whole bunch of DNS requests. Looking into the usage of `getNextMove()` in the ChessUI binary as well as it source I determined that the function works like this:

1. The function has the following signature:
```c
int getNextMove(int moveNumber, char *pieceName, int from, int to, struct aiMove)
```

2. The function composes a DNS request with the domain name: `piece-WX-YZ.game-of-thrones.flare-on.com`, where WX is the coordinates the piece is moving from and YZ is its destination coordinates. This is the same URL format as the wire trace! More cooincidences...

3. The function then performs the following checks on the resolved IP address:
```c
struct hostent *hostinfo = gethostbyname();
char *addr = hostinfo->h_addr_list[0];
if (hostinfo == NULL || addr[0] != 127 || addr[3] & 1 != 0 || addr[2] & 0xf != moveNumber) {
    return 2;
}
else {
    ...
}
return (int)(addr[3] >> 7);
```

4. Based on the usage of the function in the binary, I determined that if `getNextMove()` return 0, then it means that it is making a legal move, if it returns 1, then the player wins, otherwise the AI resigns. So, in order for the AI to make a valid move, the resolved IP address must start with 127, end in an even number, and its third byte's last four bits must be equal to the current move number.

5. I also did a quick search for the label "flag" and "flare-on" in the library file and found a global ending in "@flare-on.com" with 30 null bytes before it. `getNextMove()` also had two lines that basically did a XOR decode to populate the flag global (I renamed the label for the globals `flag` and `flagEncoded` after I figured out what they were), therefore, the IP addresses also contained the key for decoding the flag!

```c
(&flag)[moveNumber * 2] = (&flagEncoded)[moveNumber * 2] ^ addr[1];
(&flag)[moveNumber * 2 + 1] = (&flagEncoded)[moveNumber * 2 + 1] ^ addr[1];
```

So now that I understood how the `getNextMove()` function worked, I figured that I would look at how the trace made its DNS requests to see if they followed the same rules for the response IPs as imposed by the function (assuming that the packet trace represented a complete game played with the AI). BUT HA! Most of the resolved IP addresses ended in an odd byte, and those that ended in an even byte were out of order (i.e. `addr[2] & 0xf == moveNumber`). Then I realized two facts: the maximum number of moves allowed in the game were 0xf or 15 (in base 10) because only the last four bits of `addr[2]` corresponded to `moveNumber` **AND** the `flag` global had thirty NULL bytes, which makes sense as each IP address decodes two bytes. I quickly counted the number of packets in the trace with an even last byte and... **15 packets**! 

So, I figured that I just had to order the packets with an even last byte based on the third byte and then use that to decode the encoded key in the library file. So, I made a little Excel sheet to do just that!

### Solution:

**LooksLikeYouLockedUpTheLookUpZ@flare-on.com**

### Comments:

I was very happy for a Linux challenge, finally! Again, well developed and the hint was perfect, and the slight misdirection made it even more challenging. 

### Challenge Keywords:

`packet analysis`, `reversing`, `programming`