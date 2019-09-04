using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;

namespace BMPHIDE
{
	// Token: 0x02000004 RID: 4
	internal class Program
	{
		// Token: 0x0600000D RID: 13 RVA: 0x00002568 File Offset: 0x00002568
		private static void Init()
		{
			Program.yy *= 136;
			Type typeFromHandle = typeof(A);
			Program.ww += "14";
			MethodInfo[] methods = typeFromHandle.GetMethods(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
			foreach (MethodInfo methodInfo in methods)
			{
				RuntimeHelpers.PrepareMethod(methodInfo.MethodHandle);
			}
			//A.CalculateStack();
			Program.ww += "82";
			MethodInfo m = null;
			MethodInfo m2 = null;
			MethodInfo m3 = null;
			MethodInfo m4 = null;
			Program.zz = "MzQxOTk=";
			foreach (MethodInfo methodInfo2 in typeof(Program).GetMethods())
			{
				bool flag = methodInfo2.GetMethodBody() != null;
				if (flag)
				{
					byte[] ilasByteArray = methodInfo2.GetMethodBody().GetILAsByteArray();
					bool flag2 = ilasByteArray.Length > 8;
					if (flag2)
					{
						byte[] array2 = new byte[ilasByteArray.Length - 2];
						Buffer.BlockCopy(ilasByteArray, 2, array2, 0, ilasByteArray.Length - 2);
						D d = new D();
						uint num = d.a<byte>(array2);
						bool flag3 = num == 3472577156u;
						if (flag3)
						{
							m = methodInfo2;
						}
						else
						{
							bool flag4 = num == 2689456752u;
							if (flag4)
							{
								m2 = methodInfo2;
							}
							else
							{
								bool flag5 = num == 3040029055u;
								if (flag5)
								{
									m3 = methodInfo2;
								}
								else
								{
									bool flag6 = num == 2663056498u;
									if (flag6)
									{
										m4 = methodInfo2;
									}
								}
							}
						}
					}
				}
			}
			//A.VerifySignature(m, m2);
			//A.VerifySignature(m3, m4);
		}

        // Token: 0x0600000E RID: 14 RVA: 0x00002708 File Offset: 0x00002708
        public static byte a(byte b, int r)
        {
            return (byte)(((int)b + r ^ r) & 255);
        }

        
        public static byte reverse_a(byte b, int r)
        {
            return (byte)(((b & 255) ^ r) - r);
        }

        // Token: 0x0600000F RID: 15 RVA: 0x00002728 File Offset: 0x00002728
        public static byte b(byte b, int r)
		{
			for (int i = 0; i < r; i++)
			{
				byte b2 = (byte)(((int)b & 128) / 128);
				b = (byte)(((int)b * 2 & byte.MaxValue) + b2);
			}
			return b;
		}

        public static byte reverse_b(byte b, int r)
        {
            for (int i = 0; i < r; i++)
            {
                int tmp = (int)b;
                if ((b & 0x1) == 1)
                {
                    tmp = 256 | b;
                    tmp -= 1;
                }
                tmp /= 2;
                b = (byte)(tmp & Byte.MaxValue);
            }
            return b;
        }

        // Token: 0x06000010 RID: 16 RVA: 0x0000276C File Offset: 0x0000276C
        public static byte c(byte b, int r)
		{
			byte b2 = 1;
			for (int i = 0; i < 8; i++)
			{
				bool flag = (b & 1) == 1;
				if (flag)
				{
					b2 = (byte)(b2 * 2 + 1 & byte.MaxValue);
				}
				else
				{
					b2 = (byte)(b2 - 1 & byte.MaxValue);
				}
			}
			return b2;
		}

        // Token: 0x06000011 RID: 17 RVA: 0x000027BC File Offset: 0x000027BC
        public static byte d(byte b, int r)
		{
			for (int i = 0; i < r; i++)
			{
				byte b2 = (byte)((b & 1) * 128);
				b = (byte)((b / 2 & byte.MaxValue) + b2);
			}
			return b;
		}

        public static byte reverse_d(byte b, int r)
        {
            for (int i = 0; i < r; i++)
            {
                int tmp = (int)b;
                if ((b >> 7) == 1)
                {
                    tmp -= 128;
                    tmp *= 2;   
                    tmp += 1;
                }
                else
                {
                    tmp *= 2;
                }
                b = (byte)(tmp & Byte.MaxValue);
            }
            return b;
        }

        // Token: 0x06000012 RID: 18 RVA: 0x000027FC File Offset: 0x000027FC
        public static byte e(byte b, byte k)
		{
			for (int i = 0; i < 8; i++)
			{
                // Check to see if the ith bits are the same
                bool flag = (b >> i & 1) == (k >> i & 1);
				if (flag)
				{
                    // If they are, make the ith bit 0
					b = (byte)((int)b & ~(1 << i) & 255);
				}
				else
				{
                    // Else, make make the ith bit 1`
					b = (byte)((int)b | (1 << i & 255));
				}
			}
			return b;
		}
        
        public static byte reverse_e(byte b, byte k)
        {
            for (int i = 0; i < 8; i++)
            {
                // If the ith bit is 1
                bool flag = (b >> i & 1) == 0b1;
                // Then k and b are different
                if (flag)
                {
                    // Set the ith bit of b to be the opposite of the ith bit of k
                    // Zero out ith bit
                    b = (byte)((int)b & ~(1 << i) & 255);
                    // Set it to NOT k(i)
                    b = (byte)((int)b | (1 << i & ~k));
                }
                // Then k and b are the same
                else
                {
                    // Zero out ith bit
                    b = (byte)((int)b & ~(1 << i) & 255);
                    // Set it to NOT k(i)
                    b = (byte)((int)b | (1 << i & k));
                }
            }
            return b;
        }
        

        // Token: 0x06000013 RID: 19 RVA: 0x00002860 File Offset: 0x00002860
        public static byte f(int idx)
		{
			int num = 0;
			int num2 = 0;
			byte result = 0;
			int[] array = new int[]
			{
				121,
				255,
				214,
				60,
				106,
				216,
				149,
				89,
				96,
				29,
				81,
				123,
				182,
				24,
				167,
				252,
				88,
				212,
				43,
				85,
				181,
				86,
				108,
				213,
				50,
				78,
				247,
				83,
				193,
				35,
				135,
				217,
				0,
				64,
				45,
				236,
				134,
				102,
				76,
				74,
				153,
				34,
				39,
				10,
				192,
				202,
				71,
				183,
				185,
				175,
				84,
				118,
				9,
				158,
				66,
				128,
				116,
				117,
				4,
				13,
				46,
				227,
				132,
				240,
				122,
				11,
				18,
				186,
				30,
				157,
				1,
				154,
				144,
				124,
				152,
				187,
				32,
				87,
				141,
				103,
				189,
				12,
				53,
				222,
				206,
				91,
				20,
				174,
				49,
				223,
				155,
				250,
				95,
				31,
				98,
				151,
				179,
				101,
				47,
				17,
				207,
				142,
				199,
				3,
				205,
				163,
				146,
				48,
				165,
				225,
				62,
				33,
				119,
				52,
				241,
				228,
				162,
				90,
				140,
				232,
				129,
				114,
				75,
				82,
				190,
				65,
				2,
				21,
				14,
				111,
				115,
				36,
				107,
				67,
				126,
				80,
				110,
				23,
				44,
				226,
				56,
				7,
				172,
				221,
				239,
				161,
				61,
				93,
				94,
				99,
				171,
				97,
				38,
				40,
				28,
				166,
				209,
				229,
				136,
				130,
				164,
				194,
				243,
				220,
				25,
				169,
				105,
				238,
				245,
				215,
				195,
				203,
				170,
				16,
				109,
				176,
				27,
				184,
				148,
				131,
				210,
				231,
				125,
				177,
				26,
				246,
				127,
				198,
				254,
				6,
				69,
				237,
				197,
				54,
				59,
				137,
				79,
				178,
				139,
				235,
				249,
				230,
				233,
				204,
				196,
				113,
				120,
				173,
				224,
				55,
				92,
				211,
				112,
				219,
				208,
				77,
				191,
				242,
				133,
				244,
				168,
				188,
				138,
				251,
				70,
				150,
				145,
				248,
				180,
				218,
				42,
				15,
				159,
				104,
				22,
				37,
				72,
				63,
				234,
				147,
				200,
				253,
				100,
				19,
				73,
				5,
				57,
				201,
				51,
				156,
				41,
				143,
				68,
				8,
				160,
				58
			};
			for (int i = 0; i <= idx; i++)
			{
				num++;
				num %= 256;
				num2 += array[num];
				num2 %= 256;
				int num3 = array[num];
				array[num] = array[num2];
				array[num2] = num3;
				result = (byte)array[(array[num] + array[num2]) % 256];
			}
			return result;
		}

		// Token: 0x06000014 RID: 20 RVA: 0x000028F0 File Offset: 0x000028F0
		public static byte g(int idx)
		{
            byte b = (byte)((long)(idx + 1) * 0x126B6FC5);
            byte k = (byte)((idx + 2) * 0x0C82C97D);
            return Program.e(b, k);
		}

        // Token: 0x06000015 RID: 21 RVA: 0x00002924 File Offset: 0x00002924
        public static byte[] h(byte[] data)
		{
			byte[] array = new byte[data.Length];
			int num = 0;
			for (int i = 0; i < data.Length; i++)
			{
				int num2 = (int)Program.g(num++);
                Console.WriteLine(num2);
				int num3 = (int)data[i];
                Console.WriteLine(num3);
                num3 = (int)Program.e((byte)num3, (byte)num2);
                Console.WriteLine(num3);
                num3 = (int)Program.b((byte)num3, 7);
				int num4 = (int)Program.g(num++);
				num3 = (int)Program.e((byte)num3, (byte)num4);
				num3 = (int)Program.d((byte)num3, 3);
				array[i] = (byte)num3;
                Console.WriteLine("-");
			}
			return array;
		}

        public static byte[] reverse_h(byte[] data)
        {

            byte[] array = new byte[data.Length];

            // Just checking if the reverse functions work
            // Console.WriteLine(22 == Program.reverse_e(Program.e(22, 7), 7));
            // Console.WriteLine(Program.d(20, 3));
            // Console.WriteLine(Program.reverse_d(130, 3));
            int num = 0;
            for (int i = 0; i < data.Length; i++)
            {
                int num2 = (int)Program.g(num++);
                int num4 = (int)Program.g(num++);
                int num3 = (int)data[i];
                num3 = (int)Program.reverse_d((byte)num3, 3);
                num3 = (int)Program.reverse_e((byte)num3, (byte)num4);
                num3 = (int)Program.reverse_b((byte)num3, 7);
                num3 = (int)Program.reverse_e((byte)num3, (byte)num2);                
                
                array[i] = (byte)num3;
            }

            return array;
        }

        // Token: 0x06000016 RID: 22 RVA: 0x000029AC File Offset: 0x000029AC
        public static void i(Bitmap bm, byte[] data)
		{
			int num = Program.j(103);
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
					int red = ((int)pixel.R & Program.j(27)) | ((int)data[num] & Program.j(228)); // (R & 248) | (data & 7)
                    int green = ((int)pixel.G & Program.j(27)) | (data[num] >> Program.j(230) & Program.j(228)); // (G & 248) | ((data >> 3) & 7)
                    int blue = ((int)pixel.B & Program.j(25)) | (data[num] >> Program.j(100) & Program.j(230)); // (B & 252) | ((data >> 6) & 3)
                    Color color = Color.FromArgb(Program.j(103), red, green, blue);
					bm.SetPixel(i, j, color);
					num += Program.j(231);
				}
			}
		}

        // This function does the reverse of i in order to obtain the encoded data and the original bitmap
        // from a source bitmap
        public static byte[] reverse_i(Bitmap bm)
        {
            /*
             * j(103) = 0
             * j(27) = 248
             * j(231) = 1
             * j(228) = 7
             * j(230) = 3
             * j(25) = 252
             * j(100) = 6
             * */
            List<byte> output = new List<byte>();
            // This is a constant that is being used in the original i()
            int num = Program.j(103); // num = 0
            // Cycle through each pixel
            for (int i = Program.j(103); i < bm.Width; i++)
            {
                for (int j = Program.j(103); j < bm.Height; j++)
                {
                    Color pixel = bm.GetPixel(i, j);
                    byte dataByte = 0;
                    dataByte |= (byte)(pixel.B & 3);
                    dataByte = (byte)(dataByte << 3);
                    dataByte |= (byte)(pixel.G & 7);
                    dataByte = (byte)(dataByte << 3);
                    dataByte |= (byte)(pixel.R & 7);

                    output.Add(dataByte);

                    num += Program.j(231);
                }
            }

            return output.ToArray();
        }

        // Token: 0x06000017 RID: 23 RVA: 0x00002AD8 File Offset: 0x00002AD8
        public static int j(byte z)
		{
			byte b = 5;
			uint num = 0u;
			string value = "";
			byte[] bytes = new byte[8];
			for (;;)
			{
				bool flag = b == 1;
				if (flag)
				{
					num += 4u;
					b += 2;
				}
				else
				{
					bool flag2 = b == 2;
					if (flag2)
					{
						num = (uint)((ulong)num * (ulong)((long)Program.yy));
						b += 8;
					}
					else
					{
						bool flag3 = b == 3;
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

		// Token: 0x06000018 RID: 24 RVA: 0x00002C18 File Offset: 0x00002C18
		private static void Main(string[] args)
		{
			Program.Init();
			Program.yy += 18;
            // A patch that allows for the decoding of a Bitmap (I did not want to get rid of the original functionality)
            if (args[0] == "reverse")
            {
                string hiddenBMPPath = args[1];
                // open the encoded bitmap                
                Bitmap bitmap = new Bitmap(hiddenBMPPath);
                byte[] payload_encoded = Program.reverse_i(bitmap);

                byte[] payload_decoded = Program.reverse_h(payload_encoded);

                System.IO.File.WriteAllBytes(args[2], payload_decoded);
                Console.WriteLine("DONE");
            }
            else
            {
                string filename = args[2];
                string fullPath = Path.GetFullPath(args[0]);
                string fullPath2 = Path.GetFullPath(args[1]);
                byte[] data = File.ReadAllBytes(fullPath2);
                Bitmap bitmap = new Bitmap(fullPath);
                byte[] data2 = Program.h(data);
                for (int i = 0; i < data2.Length; ++i)
                {
                    Console.WriteLine(data2[i]);
                }
                Program.i(bitmap, data2);
                bitmap.Save(filename);
            }
		}

		// Token: 0x04000008 RID: 8
		public static int yy = 20;

		// Token: 0x04000009 RID: 9
		public static string ww = "1F7D";

		// Token: 0x0400000A RID: 10
		public static string zz = "MTgwMw==";
	}
}
