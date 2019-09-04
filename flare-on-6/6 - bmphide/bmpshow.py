ww = "1F7D"
yy = 20
zz = "MTgwMw=="

def un_f (encoded) :
    result = encoded
    
    array = [ 121, 255, 214, 60, 106, 216, 149, 89, 96, 29,
		81, 123, 182, 24, 167, 252, 88, 212, 43, 85, 181,
		86, 108, 213, 50, 78, 247, 83, 193, 35, 135, 217,
		0, 64, 45, 236, 134, 102, 76, 74, 153, 34, 39, 10,
		192, 202, 71, 183, 185, 175, 84, 118, 9, 158, 66,
        128, 116, 117, 4, 13, 46, 227, 132, 240, 122, 11, 
        18, 186, 30, 157, 1, 154, 144, 124, 152, 187, 32, 
        87, 141, 103, 189, 12, 53, 222, 206, 91, 20, 174,
		49, 223, 155, 250, 95, 31, 98, 151, 179, 101, 47,
		17, 207, 142, 199, 3, 205, 163, 146, 48, 165, 225,
		62, 33, 119, 52, 241, 228, 162, 90, 140, 232, 129,
		114, 75, 82, 190, 65, 2, 21, 14, 111, 115, 36, 107,
		67, 126, 80, 110, 23, 44, 226, 56, 7, 172, 221, 239,
		161, 61, 93, 94, 99, 171, 97, 38, 40, 28, 166, 209,
		229, 136, 130, 164, 194, 243, 220, 25, 169, 105,
		238, 245, 215, 195, 203, 170, 16, 109, 176, 27, 184,
		148, 131, 210, 231, 125, 177, 26, 246, 127, 198, 254,
		6, 69, 237, 197, 54, 59, 137, 79, 178, 139, 235, 249,
		230, 233, 204, 196, 113, 120, 173, 224, 55, 92, 211,
		112, 219, 208, 77, 191, 242, 133, 244, 168, 188, 138,
		251, 70, 150, 145, 248, 180, 218, 42, 15, 159, 104,
		22, 37, 72, 63, 234, 147, 200, 253, 100, 19, 73, 5,
		57, 201, 51, 156, 41, 143, 68, 8, 160, 58 ]
    
    index = array.index(result)
    index = (array[num] + array[num2]) % 256

    num++; 
    num %= 256;
    num2 += array[num];
    num2 %= 256;
    int num3 = array[num];
    array[num] = array[num2];
    array[num2] = num3;
    result = (byte)array[(array[num] + array[num2]) % 256];

def un_i (bitmap, data) :
    num = Program.j(103);
	for (int i = Program.j(103); i < bm.Width; i++)
	{
		for (int j = Program.j(103); j < bm.Height; j++)
		{
			bool flag = num > data.Length - Program.j(231);
			if (flag)
			{
				break;
			}
			Color pixel = bm.GetPixel(i, j);
			int red = ((int)pixel.R & Program.j(27)) | ((int)data[num] & Program.j(228));
			int green = ((int)pixel.G & Program.j(27)) | (data[num] >> Program.j(230) & Program.j(228));
			int blue = ((int)pixel.B & Program.j(25)) | (data[num] >> Program.j(100) & Program.j(230));
			Color color = Color.FromArgb(Program.j(103), red, green, blue);
			bm.SetPixel(i, j, color);
			num += Program.j(231);
		}
	}
    
def j (z) :
    b = 5
	num = 0
	value = ""
	byteSet = [0] * 8
	while True :
        flag = b == 1
		if flag :
			num += 4
			b += 2
		else :
            flag2 = b == 2
			if flag2 :
				num = (uint)((ulong)num * (ulong)((long)Program.yy))
				b += 8
			else :
				flag3 = b == 3
				if (flag3)
				{
					num += (uint)Program.f(6);
					b += 1;
				}
				else
				{
					bool flag4 = b == 4;
					if (flag4)
					{
						z = Program.b(z, 1);
						b += 2;
					}
					else
					{
						bool flag5 = b == 5;
						if (flag5)
						{
							num = Convert.ToUInt32(Program.ww, 16);
							b -= 3;
						}
						else
						{
							bool flag6 = b == 6;
							if (flag6)
							{
								break;
							}
							bool flag7 = b == 7;
							if (flag7)
							{
								num += Convert.ToUInt32(value);
								b -= 6;
							}
							else
							{
								bool flag8 = b == 10;
								if (flag8)
								{
									bytes = Convert.FromBase64String(Program.zz);
									b += 4;
								}
								else
								{
									bool flag9 = b == 14;
									if (flag9)
									{
										value = Encoding.Default.GetString(bytes);
										b -= 7;
									}
								}
							}
						}
					}
				}
			}
		}
	}
	return (int)Program.e(z, (byte)num);
}