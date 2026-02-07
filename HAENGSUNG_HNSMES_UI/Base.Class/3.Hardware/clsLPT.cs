using IDAT;
using System.Runtime.InteropServices;
using System.Text;

using System;

namespace HAENGSUNG_HNSMES_UI.Class
{
    class clsLPT
    {
        // LPT 관련 멤버 변수
        const uint GENERIC_READ = 0x80000000;
        const uint GENERIC_WRITE = 0x40000000;
        const uint OPEN_EXISTING = 3;
        IntPtr handle;

        [DllImport("kernel32", SetLastError = true)]
        static extern unsafe IntPtr CreateFile(
            string FileName,
            uint DesiredAccess,
            uint ShareMode,
            uint SecurityAttributes,
            uint CreationDisposition,
            uint FlagsAndAttributes,
            int hTemplateFile);

        [DllImport("kernel32", SetLastError = true)]
        static extern unsafe bool ReadFile(
            IntPtr hFile,
            void* pBuffer,
            int NumberOfBytesToRead,
            int* pNumberOfBytesRead,
            int Overlapped);

        [DllImport("kernel32", SetLastError = true)]
        static extern unsafe bool WriteFile(
            IntPtr hFile,
            void* pBuffer,
            int nBytesToWrite,
            int* nBytesWritten,
            int Overlapped);

        [DllImport("kernel32", SetLastError = true)]
        static extern int GetLastError();

        [DllImport("kernel32", SetLastError = true)]
        static extern unsafe bool CloseHandle(IntPtr hObject);

        public clsLPT()
        {
        }


        public bool Open(string FileName)
        {
            handle = CreateFile(FileName, GENERIC_READ | GENERIC_WRITE, 0, 0, OPEN_EXISTING, 0, 0);

            if (handle != IntPtr.Zero)
                return true;
            else
                return false;
        }

        public unsafe int Write(string cont)
        {
            int i = 0, n = 0;
            int Len = cont.Length;
            ASCIIEncoding e = new ASCIIEncoding();
            byte[] Buffer = e.GetBytes(cont);

            fixed (byte* p = Buffer)
            {
                i = 0;

                if (!WriteFile(handle, p + i, Len + 1, &n, 0))
                    return 0;
            }

            return n;
        }

        public bool Close()
        {
            return CloseHandle(handle);
        }
    }
}
