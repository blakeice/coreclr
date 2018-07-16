// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

/******************************************************************************
 * This file is auto-generated from a template file by the GenerateTests.csx  *
 * script in tests\src\JIT\HardwareIntrinsics\X86\Shared. In order to make    *
 * changes, please update the corresponding template and run according to the *
 * directions listed in the file.                                             *
 ******************************************************************************/

using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Intrinsics;
using System.Runtime.Intrinsics.X86;

namespace JIT.HardwareIntrinsics.X86
{
    public static partial class Program
    {
        private static void OrInt16()
        {
            var test = new SimpleBinaryOpTest__OrInt16();

            if (test.IsSupported)
            {
                // Validates basic functionality works, using Unsafe.Read
                test.RunBasicScenario_UnsafeRead();

                if (Avx.IsSupported)
                {
                    // Validates basic functionality works, using Load
                    test.RunBasicScenario_Load();

                    // Validates basic functionality works, using LoadAligned
                    test.RunBasicScenario_LoadAligned();
                }

                // Validates calling via reflection works, using Unsafe.Read
                test.RunReflectionScenario_UnsafeRead();

                if (Avx.IsSupported)
                {
                    // Validates calling via reflection works, using Load
                    test.RunReflectionScenario_Load();

                    // Validates calling via reflection works, using LoadAligned
                    test.RunReflectionScenario_LoadAligned();
                }

                // Validates passing a static member works
                test.RunClsVarScenario();

                // Validates passing a local works, using Unsafe.Read
                test.RunLclVarScenario_UnsafeRead();

                if (Avx.IsSupported)
                {
                    // Validates passing a local works, using Load
                    test.RunLclVarScenario_Load();

                    // Validates passing a local works, using LoadAligned
                    test.RunLclVarScenario_LoadAligned();
                }

                // Validates passing the field of a local class works
                test.RunClassLclFldScenario();

                // Validates passing an instance member of a class works
                test.RunClassFldScenario();

                // Validates passing the field of a local struct works
                test.RunStructLclFldScenario();

                // Validates passing an instance member of a struct works
                test.RunStructFldScenario();
            }
            else
            {
                // Validates we throw on unsupported hardware
                test.RunUnsupportedScenario();
            }

            if (!test.Succeeded)
            {
                throw new Exception("One or more scenarios did not complete as expected.");
            }
        }
    }

    public sealed unsafe class SimpleBinaryOpTest__OrInt16
    {
        private struct TestStruct
        {
            public Vector256<Int16> _fld1;
            public Vector256<Int16> _fld2;

            public static TestStruct Create()
            {
                var testStruct = new TestStruct();
                var random = new Random();

                for (var i = 0; i < Op1ElementCount; i++) { _data1[i] = (short)(random.Next(short.MinValue, short.MaxValue)); }
                Unsafe.CopyBlockUnaligned(ref Unsafe.As<Vector256<Int16>, byte>(ref testStruct._fld1), ref Unsafe.As<Int16, byte>(ref _data1[0]), (uint)Unsafe.SizeOf<Vector256<Int16>>());
                for (var i = 0; i < Op2ElementCount; i++) { _data2[i] = (short)(random.Next(short.MinValue, short.MaxValue)); }
                Unsafe.CopyBlockUnaligned(ref Unsafe.As<Vector256<Int16>, byte>(ref testStruct._fld2), ref Unsafe.As<Int16, byte>(ref _data2[0]), (uint)Unsafe.SizeOf<Vector256<Int16>>());

                return testStruct;
            }

            public void RunStructFldScenario(SimpleBinaryOpTest__OrInt16 testClass)
            {
                var result = Avx2.Or(_fld1, _fld2);

                Unsafe.Write(testClass._dataTable.outArrayPtr, result);
                testClass.ValidateResult(_fld1, _fld2, testClass._dataTable.outArrayPtr);
            }
        }

        private static readonly int LargestVectorSize = 32;

        private static readonly int Op1ElementCount = Unsafe.SizeOf<Vector256<Int16>>() / sizeof(Int16);
        private static readonly int Op2ElementCount = Unsafe.SizeOf<Vector256<Int16>>() / sizeof(Int16);
        private static readonly int RetElementCount = Unsafe.SizeOf<Vector256<Int16>>() / sizeof(Int16);

        private static Int16[] _data1 = new Int16[Op1ElementCount];
        private static Int16[] _data2 = new Int16[Op2ElementCount];

        private static Vector256<Int16> _clsVar1;
        private static Vector256<Int16> _clsVar2;

        private Vector256<Int16> _fld1;
        private Vector256<Int16> _fld2;

        private SimpleBinaryOpTest__DataTable<Int16, Int16, Int16> _dataTable;

        static SimpleBinaryOpTest__OrInt16()
        {
            var random = new Random();

            for (var i = 0; i < Op1ElementCount; i++) { _data1[i] = (short)(random.Next(short.MinValue, short.MaxValue)); }
            Unsafe.CopyBlockUnaligned(ref Unsafe.As<Vector256<Int16>, byte>(ref _clsVar1), ref Unsafe.As<Int16, byte>(ref _data1[0]), (uint)Unsafe.SizeOf<Vector256<Int16>>());
            for (var i = 0; i < Op2ElementCount; i++) { _data2[i] = (short)(random.Next(short.MinValue, short.MaxValue)); }
            Unsafe.CopyBlockUnaligned(ref Unsafe.As<Vector256<Int16>, byte>(ref _clsVar2), ref Unsafe.As<Int16, byte>(ref _data2[0]), (uint)Unsafe.SizeOf<Vector256<Int16>>());
        }

        public SimpleBinaryOpTest__OrInt16()
        {
            Succeeded = true;

            var random = new Random();

            for (var i = 0; i < Op1ElementCount; i++) { _data1[i] = (short)(random.Next(short.MinValue, short.MaxValue)); }
            Unsafe.CopyBlockUnaligned(ref Unsafe.As<Vector256<Int16>, byte>(ref _fld1), ref Unsafe.As<Int16, byte>(ref _data1[0]), (uint)Unsafe.SizeOf<Vector256<Int16>>());
            for (var i = 0; i < Op2ElementCount; i++) { _data2[i] = (short)(random.Next(short.MinValue, short.MaxValue)); }
            Unsafe.CopyBlockUnaligned(ref Unsafe.As<Vector256<Int16>, byte>(ref _fld2), ref Unsafe.As<Int16, byte>(ref _data2[0]), (uint)Unsafe.SizeOf<Vector256<Int16>>());

            for (var i = 0; i < Op1ElementCount; i++) { _data1[i] = (short)(random.Next(short.MinValue, short.MaxValue)); }
            for (var i = 0; i < Op2ElementCount; i++) { _data2[i] = (short)(random.Next(short.MinValue, short.MaxValue)); }
            _dataTable = new SimpleBinaryOpTest__DataTable<Int16, Int16, Int16>(_data1, _data2, new Int16[RetElementCount], LargestVectorSize);
        }

        public bool IsSupported => Avx2.IsSupported;

        public bool Succeeded { get; set; }

        public void RunBasicScenario_UnsafeRead()
        {
            var result = Avx2.Or(
                Unsafe.Read<Vector256<Int16>>(_dataTable.inArray1Ptr),
                Unsafe.Read<Vector256<Int16>>(_dataTable.inArray2Ptr)
            );

            Unsafe.Write(_dataTable.outArrayPtr, result);
            ValidateResult(_dataTable.inArray1Ptr, _dataTable.inArray2Ptr, _dataTable.outArrayPtr);
        }

        public void RunBasicScenario_Load()
        {
            var result = Avx2.Or(
                Avx.LoadVector256((Int16*)(_dataTable.inArray1Ptr)),
                Avx.LoadVector256((Int16*)(_dataTable.inArray2Ptr))
            );

            Unsafe.Write(_dataTable.outArrayPtr, result);
            ValidateResult(_dataTable.inArray1Ptr, _dataTable.inArray2Ptr, _dataTable.outArrayPtr);
        }

        public void RunBasicScenario_LoadAligned()
        {
            var result = Avx2.Or(
                Avx.LoadAlignedVector256((Int16*)(_dataTable.inArray1Ptr)),
                Avx.LoadAlignedVector256((Int16*)(_dataTable.inArray2Ptr))
            );

            Unsafe.Write(_dataTable.outArrayPtr, result);
            ValidateResult(_dataTable.inArray1Ptr, _dataTable.inArray2Ptr, _dataTable.outArrayPtr);
        }

        public void RunReflectionScenario_UnsafeRead()
        {
            var result = typeof(Avx2).GetMethod(nameof(Avx2.Or), new Type[] { typeof(Vector256<Int16>), typeof(Vector256<Int16>) })
                                     .Invoke(null, new object[] {
                                        Unsafe.Read<Vector256<Int16>>(_dataTable.inArray1Ptr),
                                        Unsafe.Read<Vector256<Int16>>(_dataTable.inArray2Ptr)
                                     });

            Unsafe.Write(_dataTable.outArrayPtr, (Vector256<Int16>)(result));
            ValidateResult(_dataTable.inArray1Ptr, _dataTable.inArray2Ptr, _dataTable.outArrayPtr);
        }

        public void RunReflectionScenario_Load()
        {
            var result = typeof(Avx2).GetMethod(nameof(Avx2.Or), new Type[] { typeof(Vector256<Int16>), typeof(Vector256<Int16>) })
                                     .Invoke(null, new object[] {
                                        Avx.LoadVector256((Int16*)(_dataTable.inArray1Ptr)),
                                        Avx.LoadVector256((Int16*)(_dataTable.inArray2Ptr))
                                     });

            Unsafe.Write(_dataTable.outArrayPtr, (Vector256<Int16>)(result));
            ValidateResult(_dataTable.inArray1Ptr, _dataTable.inArray2Ptr, _dataTable.outArrayPtr);
        }

        public void RunReflectionScenario_LoadAligned()
        {
            var result = typeof(Avx2).GetMethod(nameof(Avx2.Or), new Type[] { typeof(Vector256<Int16>), typeof(Vector256<Int16>) })
                                     .Invoke(null, new object[] {
                                        Avx.LoadAlignedVector256((Int16*)(_dataTable.inArray1Ptr)),
                                        Avx.LoadAlignedVector256((Int16*)(_dataTable.inArray2Ptr))
                                     });

            Unsafe.Write(_dataTable.outArrayPtr, (Vector256<Int16>)(result));
            ValidateResult(_dataTable.inArray1Ptr, _dataTable.inArray2Ptr, _dataTable.outArrayPtr);
        }

        public void RunClsVarScenario()
        {
            var result = Avx2.Or(
                _clsVar1,
                _clsVar2
            );

            Unsafe.Write(_dataTable.outArrayPtr, result);
            ValidateResult(_clsVar1, _clsVar2, _dataTable.outArrayPtr);
        }

        public void RunLclVarScenario_UnsafeRead()
        {
            var left = Unsafe.Read<Vector256<Int16>>(_dataTable.inArray1Ptr);
            var right = Unsafe.Read<Vector256<Int16>>(_dataTable.inArray2Ptr);
            var result = Avx2.Or(left, right);

            Unsafe.Write(_dataTable.outArrayPtr, result);
            ValidateResult(left, right, _dataTable.outArrayPtr);
        }

        public void RunLclVarScenario_Load()
        {
            var left = Avx.LoadVector256((Int16*)(_dataTable.inArray1Ptr));
            var right = Avx.LoadVector256((Int16*)(_dataTable.inArray2Ptr));
            var result = Avx2.Or(left, right);

            Unsafe.Write(_dataTable.outArrayPtr, result);
            ValidateResult(left, right, _dataTable.outArrayPtr);
        }

        public void RunLclVarScenario_LoadAligned()
        {
            var left = Avx.LoadAlignedVector256((Int16*)(_dataTable.inArray1Ptr));
            var right = Avx.LoadAlignedVector256((Int16*)(_dataTable.inArray2Ptr));
            var result = Avx2.Or(left, right);

            Unsafe.Write(_dataTable.outArrayPtr, result);
            ValidateResult(left, right, _dataTable.outArrayPtr);
        }

        public void RunClassLclFldScenario()
        {
            var test = new SimpleBinaryOpTest__OrInt16();
            var result = Avx2.Or(test._fld1, test._fld2);

            Unsafe.Write(_dataTable.outArrayPtr, result);
            ValidateResult(test._fld1, test._fld2, _dataTable.outArrayPtr);
        }

        public void RunClassFldScenario()
        {
            var result = Avx2.Or(_fld1, _fld2);

            Unsafe.Write(_dataTable.outArrayPtr, result);
            ValidateResult(_fld1, _fld2, _dataTable.outArrayPtr);
        }

        public void RunStructLclFldScenario()
        {
            var test = TestStruct.Create();
            var result = Avx2.Or(test._fld1, test._fld2);

            Unsafe.Write(_dataTable.outArrayPtr, result);
            ValidateResult(test._fld1, test._fld2, _dataTable.outArrayPtr);
        }

        public void RunStructFldScenario()
        {
            var test = TestStruct.Create();
            test.RunStructFldScenario(this);
        }

        public void RunUnsupportedScenario()
        {
            Succeeded = false;

            try
            {
                RunBasicScenario_UnsafeRead();
            }
            catch (PlatformNotSupportedException)
            {
                Succeeded = true;
            }
        }

        private void ValidateResult(Vector256<Int16> left, Vector256<Int16> right, void* result, [CallerMemberName] string method = "")
        {
            Int16[] inArray1 = new Int16[Op1ElementCount];
            Int16[] inArray2 = new Int16[Op2ElementCount];
            Int16[] outArray = new Int16[RetElementCount];

            Unsafe.WriteUnaligned(ref Unsafe.As<Int16, byte>(ref inArray1[0]), left);
            Unsafe.WriteUnaligned(ref Unsafe.As<Int16, byte>(ref inArray2[0]), right);
            Unsafe.CopyBlockUnaligned(ref Unsafe.As<Int16, byte>(ref outArray[0]), ref Unsafe.AsRef<byte>(result), (uint)Unsafe.SizeOf<Vector256<Int16>>());

            ValidateResult(inArray1, inArray2, outArray, method);
        }

        private void ValidateResult(void* left, void* right, void* result, [CallerMemberName] string method = "")
        {
            Int16[] inArray1 = new Int16[Op1ElementCount];
            Int16[] inArray2 = new Int16[Op2ElementCount];
            Int16[] outArray = new Int16[RetElementCount];

            Unsafe.CopyBlockUnaligned(ref Unsafe.As<Int16, byte>(ref inArray1[0]), ref Unsafe.AsRef<byte>(left), (uint)Unsafe.SizeOf<Vector256<Int16>>());
            Unsafe.CopyBlockUnaligned(ref Unsafe.As<Int16, byte>(ref inArray2[0]), ref Unsafe.AsRef<byte>(right), (uint)Unsafe.SizeOf<Vector256<Int16>>());
            Unsafe.CopyBlockUnaligned(ref Unsafe.As<Int16, byte>(ref outArray[0]), ref Unsafe.AsRef<byte>(result), (uint)Unsafe.SizeOf<Vector256<Int16>>());

            ValidateResult(inArray1, inArray2, outArray, method);
        }

        private void ValidateResult(Int16[] left, Int16[] right, Int16[] result, [CallerMemberName] string method = "")
        {
            if ((short)(left[0] | right[0]) != result[0])
            {
                Succeeded = false;
            }
            else
            {
                for (var i = 1; i < RetElementCount; i++)
                {
                    if ((short)(left[i] | right[i]) != result[i])
                    {
                        Succeeded = false;
                        break;
                    }
                }
            }

            if (!Succeeded)
            {
                Console.WriteLine($"{nameof(Avx2)}.{nameof(Avx2.Or)}<Int16>(Vector256<Int16>, Vector256<Int16>): {method} failed:");
                Console.WriteLine($"    left: ({string.Join(", ", left)})");
                Console.WriteLine($"   right: ({string.Join(", ", right)})");
                Console.WriteLine($"  result: ({string.Join(", ", result)})");
                Console.WriteLine();
            }
        }
    }
}