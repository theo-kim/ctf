using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace BMPHIDE
{
	// Token: 0x02000003 RID: 3
	public class A
	{
		// Token: 0x06000004 RID: 4 RVA: 0x000020E8 File Offset: 0x000020E8
		public static void CalculateStack()
		{
			Module module = typeof(A).Module;
			ModuleHandle moduleHandle = module.ModuleHandle;
			A.ver4 = (Environment.Version.Major == 4);
			bool flag = A.ver4;
			if (flag)
			{
				A.ver5 = (Environment.Version.Revision > 17020);
			}
			A.IdentifyLocals();
		}

		// Token: 0x06000005 RID: 5
		[DllImport("kernel32.dll")]
		private static extern IntPtr LoadLibrary(string lib);

		// Token: 0x06000006 RID: 6
		[DllImport("kernel32.dll")]
		private static extern IntPtr GetProcAddress(IntPtr lib, string proc);

		// Token: 0x06000007 RID: 7
		[DllImport("kernel32.dll")]
		private static extern bool VirtualProtect(IntPtr lpAddress, uint dwSize, uint flNewProtect, out uint lpflOldProtect);

		// Token: 0x06000008 RID: 8 RVA: 0x00002148 File Offset: 0x00002148
		private unsafe static void IdentifyLocals()
		{
			ulong* ptr = stackalloc ulong[16];
			bool flag = A.ver4;
			if (flag)
			{
				*ptr = 7218835248827755619UL;
				ptr[1] = 27756UL;
			}
			else
			{
				*ptr = 8388352820681864045UL;
				ptr[1] = 1819042862UL;
			}
			IntPtr lib = A.LoadLibrary(new string((sbyte*)ptr));
			*ptr = 127995569530215UL;
			A.getJit getJit = (A.getJit)Marshal.GetDelegateForFunctionPointer(A.GetProcAddress(lib, new string((sbyte*)ptr)), typeof(A.getJit));
			IntPtr intPtr = *getJit();
			IntPtr val = *(IntPtr*)((void*)intPtr);
			bool flag2 = IntPtr.Size == 8;
			IntPtr intPtr2;
			uint flNewProtect;
			if (flag2)
			{
				intPtr2 = Marshal.AllocHGlobal(16);
				ulong* ptr2 = (ulong*)((void*)intPtr2);
				*ptr2 = 18446744073709533256UL;
				ptr2[1] = 10416984890032521215UL;
				A.VirtualProtect(intPtr2, 12u, 64u, out flNewProtect);
				Marshal.WriteIntPtr(intPtr2, 2, val);
			}
			else
			{
				intPtr2 = Marshal.AllocHGlobal(8);
				ulong* ptr3 = (ulong*)((void*)intPtr2);
				*ptr3 = 10439625411221520312UL;
				A.VirtualProtect(intPtr2, 7u, 64u, out flNewProtect);
				Marshal.WriteIntPtr(intPtr2, 1, val);
			}
			A.originalDelegate = (A.locateNativeCallingConvention)Marshal.GetDelegateForFunctionPointer(intPtr2, typeof(A.locateNativeCallingConvention));
			A.handler = new A.locateNativeCallingConvention(A.IncrementMaxStack);
			RuntimeHelpers.PrepareDelegate(A.originalDelegate);
			RuntimeHelpers.PrepareDelegate(A.handler);
			A.VirtualProtect(intPtr, (uint)IntPtr.Size, 64u, out flNewProtect);
			Marshal.WriteIntPtr(intPtr, Marshal.GetFunctionPointerForDelegate<A.locateNativeCallingConvention>(A.handler));
			A.VirtualProtect(intPtr, (uint)IntPtr.Size, flNewProtect, out flNewProtect);
		}

		// Token: 0x06000009 RID: 9 RVA: 0x000022E0 File Offset: 0x000022E0
		public static MethodBase c(IntPtr MethodHandleValue)
		{
			foreach (Type type in Assembly.GetExecutingAssembly().GetTypes())
			{
				MethodInfo[] methods = type.GetMethods(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
				foreach (MethodInfo methodInfo in methods)
				{
					bool flag = methodInfo.MethodHandle.Value == MethodHandleValue;
					if (flag)
					{
						return methodInfo;
					}
				}
				ConstructorInfo[] constructors = type.GetConstructors(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
				foreach (ConstructorInfo constructorInfo in constructors)
				{
					bool flag2 = constructorInfo.MethodHandle.Value == MethodHandleValue;
					if (flag2)
					{
						return constructorInfo;
					}
				}
			}
			return null;
		}

		// Token: 0x0600000A RID: 10 RVA: 0x000023B8 File Offset: 0x000023B8
		private unsafe static uint IncrementMaxStack(IntPtr self, A.ICorJitInfo* comp, A.CORINFO_METHOD_INFO* info, uint flags, byte** nativeEntry, uint* nativeSizeOfCode)
		{
			bool flag = info != null;
			if (flag)
			{
				MethodBase methodBase = A.c(info->ftn);
				bool flag2 = methodBase != null;
				if (flag2)
				{
					bool flag3 = methodBase.MetadataToken == 100663317;
					if (flag3)
					{
						uint flNewProtect;
						A.VirtualProtect((IntPtr)((void*)info->ILCode), info->ILCodeSize, 4u, out flNewProtect);
						Marshal.WriteByte((IntPtr)((void*)info->ILCode), 23, 20);
						Marshal.WriteByte((IntPtr)((void*)info->ILCode), 62, 20);
						A.VirtualProtect((IntPtr)((void*)info->ILCode), info->ILCodeSize, flNewProtect, out flNewProtect);
					}
					else
					{
						bool flag4 = methodBase.MetadataToken == 100663316;
						if (flag4)
						{
							uint flNewProtect2;
							A.VirtualProtect((IntPtr)((void*)info->ILCode), info->ILCodeSize, 4u, out flNewProtect2);
							Marshal.WriteInt32((IntPtr)((void*)info->ILCode), 6, 309030853);
							Marshal.WriteInt32((IntPtr)((void*)info->ILCode), 18, 209897853);
							A.VirtualProtect((IntPtr)((void*)info->ILCode), info->ILCodeSize, flNewProtect2, out flNewProtect2);
						}
					}
				}
			}
			return A.originalDelegate(self, comp, info, flags, nativeEntry, nativeSizeOfCode);
		}

		// Token: 0x0600000B RID: 11 RVA: 0x000024F8 File Offset: 0x000024F8
		public unsafe static void VerifySignature(MethodInfo m1, MethodInfo m2)
		{
			RuntimeHelpers.PrepareMethod(m1.MethodHandle);
			RuntimeHelpers.PrepareMethod(m2.MethodHandle);
			int* ptr = (int*)((byte*)m1.MethodHandle.Value.ToPointer() + (2 * 4));
			int* ptr2 = (int*)((byte*)m2.MethodHandle.Value.ToPointer() + (2 * 4));
			*ptr = *ptr2;
		}

		// Token: 0x04000003 RID: 3
		private static A.locateNativeCallingConvention originalDelegate;

		// Token: 0x04000004 RID: 4
		private static bool ver4;

		// Token: 0x04000005 RID: 5
		private static bool ver5;

		// Token: 0x04000006 RID: 6
		private static A.locateNativeCallingConvention handler;

		// Token: 0x04000007 RID: 7
		private static bool hasLinkInfo;

		// Token: 0x02000007 RID: 7
		private struct CORINFO_EH_CLAUSE
		{
		}

		// Token: 0x02000008 RID: 8
		[StructLayout(LayoutKind.Sequential, Pack = 1)]
		private struct CORINFO_METHOD_INFO
		{
			// Token: 0x0400000E RID: 14
			public IntPtr ftn;

			// Token: 0x0400000F RID: 15
			public IntPtr scope;

			// Token: 0x04000010 RID: 16
			public unsafe byte* ILCode;

			// Token: 0x04000011 RID: 17
			public uint ILCodeSize;
		}

		// Token: 0x02000009 RID: 9
		private struct CORINFO_SIG_INFO_x64
		{
			// Token: 0x04000012 RID: 18
			public uint callConv;

			// Token: 0x04000013 RID: 19
			private uint pad1;

			// Token: 0x04000014 RID: 20
			public IntPtr retTypeClass;

			// Token: 0x04000015 RID: 21
			public IntPtr retTypeSigClass;

			// Token: 0x04000016 RID: 22
			public byte retType;

			// Token: 0x04000017 RID: 23
			public byte flags;

			// Token: 0x04000018 RID: 24
			public ushort numArgs;

			// Token: 0x04000019 RID: 25
			private uint pad2;

			// Token: 0x0400001A RID: 26
			public A.CORINFO_SIG_INST_x64 sigInst;

			// Token: 0x0400001B RID: 27
			public IntPtr args;

			// Token: 0x0400001C RID: 28
			public IntPtr sig;

			// Token: 0x0400001D RID: 29
			public IntPtr scope;

			// Token: 0x0400001E RID: 30
			public uint token;

			// Token: 0x0400001F RID: 31
			private uint pad3;
		}

		// Token: 0x0200000A RID: 10
		private struct CORINFO_SIG_INFO_x86
		{
			// Token: 0x04000020 RID: 32
			public uint callConv;

			// Token: 0x04000021 RID: 33
			public IntPtr retTypeClass;

			// Token: 0x04000022 RID: 34
			public IntPtr retTypeSigClass;

			// Token: 0x04000023 RID: 35
			public byte retType;

			// Token: 0x04000024 RID: 36
			public byte flags;

			// Token: 0x04000025 RID: 37
			public ushort numArgs;

			// Token: 0x04000026 RID: 38
			public A.CORINFO_SIG_INST_x86 sigInst;

			// Token: 0x04000027 RID: 39
			public IntPtr args;

			// Token: 0x04000028 RID: 40
			public IntPtr sig;

			// Token: 0x04000029 RID: 41
			public IntPtr scope;

			// Token: 0x0400002A RID: 42
			public uint token;
		}

		// Token: 0x0200000B RID: 11
		private struct CORINFO_SIG_INST_x64
		{
		}

		// Token: 0x0200000C RID: 12
		private struct CORINFO_SIG_INST_x86
		{
		}

		// Token: 0x0200000D RID: 13
		private struct ICorClassInfo
		{
			// Token: 0x0400002B RID: 43
			public unsafe readonly IntPtr* vfptr;
		}

		// Token: 0x0200000E RID: 14
		private struct ICorDynamicInfo
		{
			// Token: 0x0600001E RID: 30 RVA: 0x00002CE0 File Offset: 0x00002CE0
			public unsafe static A.ICorStaticInfo* ICorStaticInfo(A.ICorDynamicInfo* ptr)
			{
				return (A.ICorStaticInfo*)(&ptr->vbptr) + ptr->vbptr[(A.hasLinkInfo ? 9 : 8) * 4] / sizeof(A.ICorStaticInfo);
			}

			// Token: 0x0400002C RID: 44
			public unsafe IntPtr* vfptr;

			// Token: 0x0400002D RID: 45
			public unsafe int* vbptr;
		}

		// Token: 0x0200000F RID: 15
		private struct ICorJitInfo
		{
			// Token: 0x0600001F RID: 31 RVA: 0x00002D14 File Offset: 0x00002D14
			public unsafe static A.ICorDynamicInfo* ICorDynamicInfo(A.ICorJitInfo* ptr)
			{
				A.hasLinkInfo = (ptr->vbptr[10] > 0 && ptr->vbptr[10] >> 16 == 0);
				return (A.ICorDynamicInfo*)(&ptr->vbptr) + ptr->vbptr[(A.hasLinkInfo ? 10 : 9) * 4] / sizeof(A.ICorDynamicInfo);
			}

			// Token: 0x0400002E RID: 46
			public unsafe IntPtr* vfptr;

			// Token: 0x0400002F RID: 47
			public unsafe int* vbptr;
		}

		// Token: 0x02000010 RID: 16
		private struct ICorMethodInfo
		{
			// Token: 0x04000030 RID: 48
			public unsafe IntPtr* vfptr;
		}

		// Token: 0x02000011 RID: 17
		private struct ICorModuleInfo
		{
			// Token: 0x04000031 RID: 49
			public unsafe IntPtr* vfptr;
		}

		// Token: 0x02000012 RID: 18
		private struct ICorStaticInfo
		{
			// Token: 0x06000020 RID: 32 RVA: 0x00002D74 File Offset: 0x00002D74
			public unsafe static A.ICorMethodInfo* ICorMethodInfo(A.ICorStaticInfo* ptr)
			{
				return (A.ICorMethodInfo*)(&ptr->vbptr) + ptr->vbptr[1] / sizeof(A.ICorMethodInfo);
			}

			// Token: 0x06000021 RID: 33 RVA: 0x00002D98 File Offset: 0x00002D98
			public unsafe static A.ICorModuleInfo* ICorModuleInfo(A.ICorStaticInfo* ptr)
			{
				return (A.ICorModuleInfo*)(&ptr->vbptr) + ptr->vbptr[2] / sizeof(A.ICorModuleInfo);
			}

			// Token: 0x06000022 RID: 34 RVA: 0x00002DC0 File Offset: 0x00002DC0
			public unsafe static A.ICorClassInfo* ICorClassInfo(A.ICorStaticInfo* ptr)
			{
				return (A.ICorClassInfo*)(&ptr->vbptr) + ptr->vbptr[3] / sizeof(A.ICorClassInfo);
			}

			// Token: 0x04000032 RID: 50
			public unsafe IntPtr* vfptr;

			// Token: 0x04000033 RID: 51
			public unsafe int* vbptr;
		}

		// Token: 0x02000013 RID: 19
		private class CorMethodInfoHook
		{
			// Token: 0x06000023 RID: 35 RVA: 0x00002DE8 File Offset: 0x00002DE8
			private unsafe void hookEHInfo(IntPtr self, IntPtr ftn, uint EHnumber, A.CORINFO_EH_CLAUSE* clause)
			{
				bool flag = ftn == this.ftn;
				if (flag)
				{
					*clause = this.clauses[(ulong)EHnumber * (ulong)((long)sizeof(A.CORINFO_EH_CLAUSE)) / (ulong)sizeof(A.CORINFO_EH_CLAUSE)];
				}
				else
				{
					this.o_getEHinfo(self, ftn, EHnumber, clause);
				}
			}

			// Token: 0x06000024 RID: 36 RVA: 0x00002E3B File Offset: 0x00002E3B
			public unsafe void Dispose()
			{
				Marshal.FreeHGlobal((IntPtr)((void*)this.newVfTbl));
				this.info->vfptr = this.oldVfTbl;
			}

			// Token: 0x06000025 RID: 37 RVA: 0x00002E60 File Offset: 0x00002E60
			public unsafe static A.CorMethodInfoHook Hook(A.ICorJitInfo* comp, IntPtr ftn, A.CORINFO_EH_CLAUSE* clauses)
			{
				A.ICorMethodInfo* ptr = A.ICorStaticInfo.ICorMethodInfo(A.ICorDynamicInfo.ICorStaticInfo(A.ICorJitInfo.ICorDynamicInfo(comp)));
				IntPtr* vfptr = ptr->vfptr;
				IntPtr* ptr2 = (IntPtr*)((void*)Marshal.AllocHGlobal(27 * IntPtr.Size));
				for (int i = 0; i < 27; i++)
				{
					ptr2[i * sizeof(IntPtr) / sizeof(IntPtr)] = vfptr[i * sizeof(IntPtr) / sizeof(IntPtr)];
				}
				bool flag = A.CorMethodInfoHook.ehNum == -1;
				if (flag)
				{
					for (int j = 0; j < 27; j++)
					{
						bool flag2 = true;
						byte* ptr3 = (byte*)((void*)vfptr[j * sizeof(IntPtr) / sizeof(IntPtr)]);
						while (*ptr3 != 233)
						{
							bool flag3 = (IntPtr.Size == 8) ? (*ptr3 == 72 && ptr3[1] == 129 && ptr3[2] == 233) : (*ptr3 == 131 && ptr3[1] == 233);
							if (flag3)
							{
								flag2 = false;
								break;
							}
							ptr3++;
						}
						bool flag4 = flag2;
						if (flag4)
						{
							A.CorMethodInfoHook.ehNum = j;
							break;
						}
					}
				}
				A.CorMethodInfoHook corMethodInfoHook = new A.CorMethodInfoHook
				{
					ftn = ftn,
					info = ptr,
					clauses = clauses,
					newVfTbl = ptr2,
					oldVfTbl = vfptr
				};
				corMethodInfoHook.n_getEHinfo = new A.getEHinfo(corMethodInfoHook.hookEHInfo);
				corMethodInfoHook.o_getEHinfo = (A.getEHinfo)Marshal.GetDelegateForFunctionPointer(vfptr[A.CorMethodInfoHook.ehNum * sizeof(IntPtr) / sizeof(IntPtr)], typeof(A.getEHinfo));
				ptr2[A.CorMethodInfoHook.ehNum * sizeof(IntPtr) / sizeof(IntPtr)] = Marshal.GetFunctionPointerForDelegate<A.getEHinfo>(corMethodInfoHook.n_getEHinfo);
				ptr->vfptr = ptr2;
				return corMethodInfoHook;
			}

			// Token: 0x04000034 RID: 52
			private static int ehNum = -1;

			// Token: 0x04000035 RID: 53
			public unsafe A.CORINFO_EH_CLAUSE* clauses;

			// Token: 0x04000036 RID: 54
			public IntPtr ftn;

			// Token: 0x04000037 RID: 55
			public unsafe A.ICorMethodInfo* info;

			// Token: 0x04000038 RID: 56
			public A.getEHinfo n_getEHinfo;

			// Token: 0x04000039 RID: 57
			public unsafe IntPtr* newVfTbl;

			// Token: 0x0400003A RID: 58
			public A.getEHinfo o_getEHinfo;

			// Token: 0x0400003B RID: 59
			public unsafe IntPtr* oldVfTbl;
		}

		// Token: 0x02000014 RID: 20
		private class CorJitInfoHook
		{
			// Token: 0x06000028 RID: 40 RVA: 0x00003028 File Offset: 0x00003028
			private unsafe void hookEHInfo(IntPtr self, IntPtr ftn, uint EHnumber, A.CORINFO_EH_CLAUSE* clause)
			{
				bool flag = ftn == this.ftn;
				if (flag)
				{
					*clause = this.clauses[(ulong)EHnumber * (ulong)((long)sizeof(A.CORINFO_EH_CLAUSE)) / (ulong)sizeof(A.CORINFO_EH_CLAUSE)];
				}
				else
				{
					this.o_getEHinfo(self, ftn, EHnumber, clause);
				}
			}

			// Token: 0x06000029 RID: 41 RVA: 0x0000307B File Offset: 0x0000307B
			public unsafe void Dispose()
			{
				Marshal.FreeHGlobal((IntPtr)((void*)this.newVfTbl));
				this.info->vfptr = this.oldVfTbl;
			}

			// Token: 0x0600002A RID: 42 RVA: 0x000030A0 File Offset: 0x000030A0
			public unsafe static A.CorJitInfoHook Hook(A.ICorJitInfo* comp, IntPtr ftn, A.CORINFO_EH_CLAUSE* clauses)
			{
				IntPtr* vfptr = comp->vfptr;
				IntPtr* ptr = (IntPtr*)((void*)Marshal.AllocHGlobal(158 * IntPtr.Size));
				for (int i = 0; i < 158; i++)
				{
					ptr[i * sizeof(IntPtr) / sizeof(IntPtr)] = vfptr[i * sizeof(IntPtr) / sizeof(IntPtr)];
				}
				A.CorJitInfoHook corJitInfoHook = new A.CorJitInfoHook
				{
					ftn = ftn,
					info = comp,
					clauses = clauses,
					newVfTbl = ptr,
					oldVfTbl = vfptr
				};
				corJitInfoHook.n_getEHinfo = new A.getEHinfo(corJitInfoHook.hookEHInfo);
				corJitInfoHook.o_getEHinfo = (A.getEHinfo)Marshal.GetDelegateForFunctionPointer(vfptr[8 * sizeof(IntPtr) / sizeof(IntPtr)], typeof(A.getEHinfo));
				ptr[8 * sizeof(IntPtr) / sizeof(IntPtr)] = Marshal.GetFunctionPointerForDelegate<A.getEHinfo>(corJitInfoHook.n_getEHinfo);
				comp->vfptr = ptr;
				return corJitInfoHook;
			}

			// Token: 0x0400003C RID: 60
			public unsafe A.CORINFO_EH_CLAUSE* clauses;

			// Token: 0x0400003D RID: 61
			public IntPtr ftn;

			// Token: 0x0400003E RID: 62
			public unsafe A.ICorJitInfo* info;

			// Token: 0x0400003F RID: 63
			public A.getEHinfo n_getEHinfo;

			// Token: 0x04000040 RID: 64
			public unsafe IntPtr* newVfTbl;

			// Token: 0x04000041 RID: 65
			public A.getEHinfo o_getEHinfo;

			// Token: 0x04000042 RID: 66
			public unsafe IntPtr* oldVfTbl;
		}

		// Token: 0x02000015 RID: 21
		private struct MethodData
		{
			// Token: 0x04000043 RID: 67
			public readonly uint ILCodeSize;

			// Token: 0x04000044 RID: 68
			public readonly uint MaxStack;

			// Token: 0x04000045 RID: 69
			public readonly uint EHCount;

			// Token: 0x04000046 RID: 70
			public readonly uint LocalVars;

			// Token: 0x04000047 RID: 71
			public readonly uint Options;

			// Token: 0x04000048 RID: 72
			public readonly uint MulSeed;
		}

		// Token: 0x02000016 RID: 22
		// (Invoke) Token: 0x0600002D RID: 45
		[UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private unsafe delegate uint locateNativeCallingConvention(IntPtr self, A.ICorJitInfo* comp, A.CORINFO_METHOD_INFO* info, uint flags, byte** nativeEntry, uint* nativeSizeOfCode);

		// Token: 0x02000017 RID: 23
		// (Invoke) Token: 0x06000031 RID: 49
		[UnmanagedFunctionPointer(CallingConvention.ThisCall)]
		private unsafe delegate void getEHinfo(IntPtr self, IntPtr ftn, uint EHnumber, A.CORINFO_EH_CLAUSE* clause);

		// Token: 0x02000018 RID: 24
		// (Invoke) Token: 0x06000035 RID: 53
		private unsafe delegate IntPtr* getJit();

		// Token: 0x02000019 RID: 25
		// (Invoke) Token: 0x06000039 RID: 57
		[UnmanagedFunctionPointer(CallingConvention.ThisCall)]
		private delegate uint getMethodDefFromMethod(IntPtr self, IntPtr ftn);
	}
}
