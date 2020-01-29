uid = "82cd297adedacf3322e39894b8856d10"

length = 0

delay = 0
i = 0
while True :
    length = len(uid)
    if (length <= i) :
        break
    trans = ord(uid[i]) >> 7
    print(bin(ord(uid[i]))[2:].zfill(8))
    i += 1

#print(delay)
