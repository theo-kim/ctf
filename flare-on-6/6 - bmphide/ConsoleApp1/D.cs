using System;
using System.Collections.Generic;
using System.Linq;

namespace BMPHIDE
{
	// Token: 0x02000002 RID: 2
	public class D
	{
		// Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00002050
		public D()
		{
			this.m_checksumTable = Enumerable.Range(0, 256).Select(delegate(int i)
			{
				uint num = (uint)i;
				for (int j = 0; j < 8; j++)
				{
					num = (((num & 1u) != 0u) ? (1611621881u ^ num >> 1) : (num >> 1));
				}
				return num;
			}).ToArray<uint>();
		}

		// Token: 0x06000002 RID: 2 RVA: 0x000020A0 File Offset: 0x000020A0
		public uint a<T>(IEnumerable<T> byteStream)
		{
			return ~byteStream.Aggregate(uint.MaxValue, (uint checksumRegister, T currentByte) => this.m_checksumTable[(int)((checksumRegister & 255u) ^ (uint)Convert.ToByte(currentByte))] ^ checksumRegister >> 8);
		}

		// Token: 0x04000001 RID: 1
		private const uint s_generator = 1611621881u;

		// Token: 0x04000002 RID: 2
		private readonly uint[] m_checksumTable;
	}
}
