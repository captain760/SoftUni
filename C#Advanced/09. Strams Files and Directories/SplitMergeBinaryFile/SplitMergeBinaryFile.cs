using System.IO;
namespace SplitMergeBinaryFile
{
    public class SplitMergeBinaryFile
    {
        static void Main(string[] args)
        {
            string sourceFilePath = @"..\..\..\Files\example.png";
            string joinedFilePath = @"..\..\..\Files\example-joined.png";
            string partOnePath = @"..\..\..\Files\part-1.bin";
            string partTwoPath = @"..\..\..\Files\part-2.bin";

            SplitBinaryFile(sourceFilePath, partOnePath, partTwoPath);
            MergeBinaryFiles(partOnePath, partTwoPath, joinedFilePath);
        }

        public static void SplitBinaryFile(string sourceFilePath, string partOneFilePath, string partTwoFilePath)
        {
            byte[] bytesRead = File.ReadAllBytes(sourceFilePath);
            long halfBytes = bytesRead.Length / 2;
            long halfLength = 0;
            if (halfBytes%2 == 1)
            {
                halfLength = halfBytes+1;
            }
            else
            {
                halfLength = halfBytes;
            }
            byte[] firstHalf = new byte[halfLength];
            byte[] secondHalf = new byte[halfBytes];
            for (int i = 0; i < firstHalf.Length; i++)
            {
                firstHalf[i] = bytesRead[i];               
            }
            for (int i = 0; i < secondHalf.Length; i++)
            {
                secondHalf[i] = bytesRead[halfLength + i];
            }
            File.WriteAllBytes(partOneFilePath, firstHalf);
            File.WriteAllBytes(partTwoFilePath, secondHalf);
        }

        public static void MergeBinaryFiles(string partOneFilePath, string partTwoFilePath, string joinedFilePath)
        {
            byte[] partOne = File.ReadAllBytes(partOneFilePath);
            byte[] partTwo = File.ReadAllBytes(partTwoFilePath);
            byte[] merged = new byte[partOne.Length + partTwo.Length];
            for (int i = 0; i < partOne.Length; i++)
            {
                merged[i] = partOne[i];
            }
            for (int i = 0; i < partTwo.Length; i++)
            {
                merged[partOne.Length + i] = partTwo[i];
            }
            File.WriteAllBytes(joinedFilePath, merged);
        }
    }
}