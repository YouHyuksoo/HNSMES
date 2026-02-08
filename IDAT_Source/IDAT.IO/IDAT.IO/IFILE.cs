using System.IO;
using System.Text;

namespace IDAT.IO;

internal interface IFILE
{
	long GetSizeFile(string strFilePath);

	long GetSizeFolder(string strFolderPath);

	void Copy_File(string strCopyFilepath, string strToCopyDirectoryPath);

	void Copy_File(string strCopyFilepath, string strToCopyDirectoryPath, bool bFileOverwrite);

	void Move_File(string strMoveFilepath, string strToMoveDirectoryPath);

	void Delete_Folder_All_File(string strFolderPath);

	void Copy_Folder_All_File(string strFromFolder_path, string strTofolderPath);

	void Delete_File(string strFilePath);

	void Create_File(string strCreateFilePath);

	void Create_Folder(string strCreateFolderPath);

	void Delete_Folder(string strDeleteFolderPath);

	void Move_Folder(string strFromFolderPath, string strToFolderPath);

	bool File_Compare(string strFile_1, string strFile_2);

	void ALL_Folder_File_Copy(string strFromFolderPath, string strToFolderPath);

	bool File_exist(string file_name);

	string File_Read(string file_name);

	void Create_File_Write_Data(string file_name, StringBuilder sb, bool append);

	MemoryStream Read_File_Data_MemoryStream(string file_name);

	string Check_File_Name(string str);
}
