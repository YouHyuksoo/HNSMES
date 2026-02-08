using System;
using System.IO;
using System.Text;

namespace IDAT.IO;

public class FILE : IFILE
{
	public long GetSizeFile(string strFilePath)
	{
		if (File.Exists(strFilePath))
		{
			FileInfo fileInfo = new FileInfo(strFilePath);
			return fileInfo.Length;
		}
		return 0L;
	}

	public long GetSizeFolder(string strFolderPath)
	{
		long num = 0L;
		if (Directory.Exists(strFolderPath))
		{
			DirectoryInfo directoryInfo = new DirectoryInfo(strFolderPath);
			FileInfo[] files = directoryInfo.GetFiles();
			FileInfo[] array = files;
			foreach (FileInfo fileInfo in array)
			{
				num += fileInfo.Length;
			}
			return num;
		}
		return 0L;
	}

	public void Copy_File(string strCopyFilepath, string strToCopyDirectoryPath)
	{
		if (File.Exists(strCopyFilepath))
		{
			if (!Directory.Exists(strToCopyDirectoryPath.Substring(0, strToCopyDirectoryPath.LastIndexOf("\\"))))
			{
				Directory.CreateDirectory(strToCopyDirectoryPath.Substring(0, strToCopyDirectoryPath.LastIndexOf("\\")));
			}
			File.Delete(strToCopyDirectoryPath);
			File.Copy(strCopyFilepath, strToCopyDirectoryPath, overwrite: true);
		}
	}

	public void Copy_File(string strCopyFilepath, string strToCopyDirectoryPath, bool bFileOverwrite)
	{
		if (!bFileOverwrite)
		{
			string[] array = DividePath(strToCopyDirectoryPath);
			string text = array[0];
			string text2 = array[1];
			string text3 = text + "\\" + text2;
			int num = 1;
			while (File.Exists(text3))
			{
				text3 = RenameFile(strToCopyDirectoryPath, num);
				num++;
			}
			strToCopyDirectoryPath = text3;
		}
		File.Copy(strCopyFilepath, strToCopyDirectoryPath, overwrite: true);
	}

	private string[] DividePath(string path)
	{
		int num = path.LastIndexOf('\\');
		string text = path.Substring(0, num);
		string text2 = path.Substring(num + 1, path.Length - num - 1);
		return new string[2] { text, text2 };
	}

	public string RenameFile(string filename, int cnt)
	{
		int num = filename.LastIndexOf('.');
		string text = filename.Substring(0, num);
		string text2 = filename.Substring(num, filename.Length - num);
		filename = text + "(" + cnt + ")" + text2;
		return filename;
	}

	public void Move_File(string strMoveFilepath, string strToMoveDirectoryPath)
	{
		if (File.Exists(strMoveFilepath))
		{
			if (!Directory.Exists(strToMoveDirectoryPath.Substring(0, strToMoveDirectoryPath.LastIndexOf("\\"))))
			{
				Directory.CreateDirectory(strToMoveDirectoryPath.Substring(0, strToMoveDirectoryPath.LastIndexOf("\\")));
			}
			File.Delete(strToMoveDirectoryPath);
			File.Move(strMoveFilepath, strToMoveDirectoryPath);
		}
	}

	public void Delete_Folder_All_File(string strFolderPath)
	{
		if (Directory.Exists(strFolderPath))
		{
			DirectoryInfo directoryInfo = new DirectoryInfo(strFolderPath);
			FileInfo[] files = directoryInfo.GetFiles();
			FileInfo[] array = files;
			foreach (FileInfo fileInfo in array)
			{
				fileInfo.Delete();
			}
		}
		else
		{
			Directory.CreateDirectory(strFolderPath);
		}
	}

	public void Copy_Folder_All_File(string strFromFolder_path, string strTofolderPath)
	{
		if (Directory.Exists(strFromFolder_path))
		{
			if (!Directory.Exists(strTofolderPath))
			{
				Directory.CreateDirectory(strTofolderPath);
			}
			DirectoryInfo directoryInfo = new DirectoryInfo(strFromFolder_path);
			FileInfo[] files = directoryInfo.GetFiles();
			FileInfo[] array = files;
			foreach (FileInfo fileInfo in array)
			{
				File.Copy(fileInfo.FullName, strTofolderPath + "\\" + fileInfo.Name, overwrite: true);
			}
		}
	}

	public void Delete_File(string strFilePath)
	{
		if (File.Exists(strFilePath))
		{
			File.Delete(strFilePath);
		}
	}

	public void Create_File(string strCreateFilePath)
	{
		if (!File.Exists(strCreateFilePath))
		{
			if (!Directory.Exists(strCreateFilePath.Substring(0, strCreateFilePath.LastIndexOf("\\"))))
			{
				Directory.CreateDirectory(strCreateFilePath.Substring(0, strCreateFilePath.LastIndexOf("\\")));
			}
			File.Create(strCreateFilePath);
		}
	}

	public void Create_Folder(string strCreateFolderPath)
	{
		if (!Directory.Exists(strCreateFolderPath))
		{
			Directory.CreateDirectory(strCreateFolderPath);
		}
	}

	public void Delete_Folder(string strDeleteFolderPath)
	{
		if (Directory.Exists(strDeleteFolderPath))
		{
			Directory.Delete(strDeleteFolderPath, recursive: true);
		}
	}

	public void Move_Folder(string strFromFolderPath, string strToFolderPath)
	{
		if (Directory.Exists(strFromFolderPath))
		{
			Create_Folder(strToFolderPath);
			DirectoryInfo directoryInfo = new DirectoryInfo(strFromFolderPath);
			FileInfo[] files = directoryInfo.GetFiles();
			foreach (FileInfo fileInfo in files)
			{
				fileInfo.MoveTo(strToFolderPath + "\\" + fileInfo.Name);
			}
			directoryInfo.Delete(recursive: true);
		}
	}

	public bool File_Compare(string strFile_1, string strFile_2)
	{
		try
		{
			if (strFile_1.Trim().Equals(""))
			{
				return false;
			}
			string[] array = strFile_1.Split('.');
			StringBuilder stringBuilder = new StringBuilder();
			string text = "";
			for (int i = 0; i < array.Length - 1; i++)
			{
				stringBuilder.Append(array[i] + ".");
			}
			text = stringBuilder.ToString().Substring(0, stringBuilder.Length - 1);
			string text2 = array[array.Length - 1].Trim();
			string[] array2 = strFile_2.Split('.');
			StringBuilder stringBuilder2 = new StringBuilder();
			string text3 = "";
			for (int i = 0; i < array2.Length - 1; i++)
			{
				stringBuilder2.Append(array2[i] + ".");
			}
			text3 = stringBuilder2.ToString().Substring(0, stringBuilder2.Length - 1);
			string value = array2[array2.Length - 1].Trim();
			if (text.IndexOf("*") > -1)
			{
				if (text2.IndexOf("*") > -1)
				{
					return true;
				}
				if (text2.Equals(value))
				{
					return true;
				}
				return false;
			}
			if (text.Equals(text3))
			{
				if (text2.IndexOf("*") > -1)
				{
					return true;
				}
				if (text2.Equals(value))
				{
					return true;
				}
				return false;
			}
			return false;
		}
		catch
		{
			return false;
		}
	}

	public void ALL_Folder_File_Copy(string strFromFolderPath, string strToFolderPath)
	{
		if (Directory.Exists(strFromFolderPath))
		{
			int num = 1;
			DirectoryInfo directoryInfo = new DirectoryInfo(strFromFolderPath);
			string text = strToFolderPath + "\\" + directoryInfo.Name;
			while (Directory.Exists(text))
			{
				text = strToFolderPath + "\\" + directoryInfo.Name + "(" + num + ")";
				num++;
			}
			Directory.CreateDirectory(text);
			CopyFolderProcess(strFromFolderPath, text);
		}
	}

	private void CopyFolderProcess(string source, string target)
	{
		DirectoryInfo directoryInfo = new DirectoryInfo(source);
		FileSystemInfo[] fileSystemInfos = directoryInfo.GetFileSystemInfos();
		string text = "";
		FileSystemInfo[] array = fileSystemInfos;
		foreach (FileSystemInfo fileSystemInfo in array)
		{
			text = target + "\\" + fileSystemInfo.Name;
			if (FileAttributes.Directory == fileSystemInfo.Attributes)
			{
				Directory.CreateDirectory(text);
				CopyFolderProcess(fileSystemInfo.FullName, text);
			}
			else
			{
				File.Copy(fileSystemInfo.FullName, text);
			}
		}
	}

	public bool File_exist(string file_name)
	{
		try
		{
			FileInfo fileInfo = new FileInfo(file_name);
			return fileInfo.Exists;
		}
		catch
		{
			return false;
		}
	}

	public string File_Read(string file_name)
	{
		string result = "";
		using (StreamReader streamReader = new StreamReader(file_name, Encoding.Default))
		{
			result = streamReader.ReadToEnd();
			streamReader.Close();
		}
		return result;
	}

	public void Create_File_Write_Data(string file_name, StringBuilder sb, bool append)
	{
		if (!Directory.Exists(file_name.Substring(0, file_name.LastIndexOf("\\"))))
		{
			Directory.CreateDirectory(file_name.Substring(0, file_name.LastIndexOf("\\")));
		}
		using StreamWriter streamWriter = new StreamWriter(file_name, append, Encoding.Default);
		streamWriter.Write(sb);
		streamWriter.Close();
	}

	public MemoryStream Read_File_Data_MemoryStream(string file_name)
	{
		MemoryStream memoryStream = new MemoryStream();
		if (!Directory.Exists(file_name.Substring(0, file_name.LastIndexOf("\\"))))
		{
			Directory.CreateDirectory(file_name.Substring(0, file_name.LastIndexOf("\\")));
		}
		using (StreamReader streamReader = new StreamReader(file_name, Encoding.Default))
		{
			byte[] bytes = Encoding.Default.GetBytes(streamReader.ReadToEnd());
			memoryStream.Write(bytes, 0, bytes.Length);
			streamReader.Close();
		}
		return memoryStream;
	}

	public string Check_File_Name(string str)
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(str);
		stringBuilder.Replace("\\", "");
		stringBuilder.Replace("/", "");
		stringBuilder.Replace(":", "");
		stringBuilder.Replace("?", "");
		stringBuilder.Replace("\"", "");
		stringBuilder.Replace("<", "");
		stringBuilder.Replace(">", "");
		stringBuilder.Replace("|", "");
		stringBuilder.Replace("*", "");
		return stringBuilder.ToString();
	}

	public string Get_Size(int d_long)
	{
		try
		{
			return Get_Size(Convert.ToDecimal(d_long));
		}
		catch
		{
			return "0 Byte";
		}
	}

	public string Get_Size(long d_long)
	{
		try
		{
			return Get_Size(Convert.ToDecimal(d_long));
		}
		catch
		{
			return "0 Byte";
		}
	}

	public string Get_Size(string d_long)
	{
		try
		{
			return Get_Size(Convert.ToDecimal(d_long));
		}
		catch
		{
			return "0 Byte";
		}
	}

	public string Get_Size(decimal d_long)
	{
		try
		{
			if (d_long == 0m)
			{
				return "0 byte";
			}
			if (d_long > 1024m)
			{
				if (d_long > 1048576m)
				{
					if (d_long > 1073741824m)
					{
						return $"{d_long / 1073741824m:n1}" + " GB";
					}
					return $"{d_long / 1048576m:n1}" + " MB";
				}
				return $"{d_long / 1024m:n1}" + " KB";
			}
			return $"{d_long:n1}" + " byte";
		}
		catch
		{
			return "0 byte";
		}
	}
}
