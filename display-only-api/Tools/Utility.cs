
using System.IO;
using System.IO.Compression;

namespace display_only_api.Tools;

public class Utility{


    // public static void Compress(FileInfo fileToCompress)
    // {
    //     using (FileStream originalFileStream = fileToCompress.OpenRead())
    //     {
    //         if ((File.GetAttributes(fileToCompress.FullName) & FileAttributes.Hidden) != FileAttributes.Hidden & fileToCompress.Extension != ".gz")
    //         {
    //             using (FileStream compressedFileStream = File.Create(fileToCompress.FullName + ".gz"))
    //             {
    //                 using (GZipStream compressionStream = new GZipStream(compressedFileStream, CompressionMode.Compress))
    //                 {
    //                     originalFileStream.CopyTo(compressionStream);
    //                     Console.WriteLine("Compressed {0} from {1} to {2} bytes.",
    //                         fileToCompress.Name, fileToCompress.Length.ToString(), compressedFileStream.Length.ToString());
    //                 }
    //             }
    //         }
    //     }
    // }

    public static async Task<byte[]> Decompress(Stream stream)
    {
        using(GZipStream decompressionStream = new GZipStream(stream, CompressionMode.Decompress)){

            using(MemoryStream target = new MemoryStream()){

                await decompressionStream.CopyToAsync(target);
                
                return target.ToArray();
            }
        }
        // MemoryStream target = new MemoryStream();
        // await decompressionStream.CopyToAsync(target);
        // return target;
        
        
        
    }

}
