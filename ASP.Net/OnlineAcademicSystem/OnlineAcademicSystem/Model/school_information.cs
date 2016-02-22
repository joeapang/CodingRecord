using System;
namespace OnlineAcademicSystem.Model
{
	/// <summary>
	/// school_information:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class school_information
	{
		public school_information()
		{}
		#region Model
		private string _school_information_id;
		private string _school_information_name;
		/// <summary>
		/// 
		/// </summary>
		public string school_information_id
		{
			set{ _school_information_id=value;}
			get{return _school_information_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string school_information_name
		{
			set{ _school_information_name=value;}
			get{return _school_information_name;}
		}
		#endregion Model

	}
}

