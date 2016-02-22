using System;
namespace OnlineAcademicSystem.Model
{
	/// <summary>
	/// teacher:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class teacher
	{
		public teacher()
		{}
		#region Model
		private string _teacher_id;
		private string _teacher_position_id;
		private string _major_id;
		private string _teacher_name;
		private bool _teacher_sex;
		private string _teacher_tel;
		private string _teacher_password;
		/// <summary>
		/// 
		/// </summary>
		public string teacher_id
		{
			set{ _teacher_id=value;}
			get{return _teacher_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string teacher_position_id
		{
			set{ _teacher_position_id=value;}
			get{return _teacher_position_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string major_id
		{
			set{ _major_id=value;}
			get{return _major_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string teacher_name
		{
			set{ _teacher_name=value;}
			get{return _teacher_name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool teacher_sex
		{
			set{ _teacher_sex=value;}
			get{return _teacher_sex;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string teacher_tel
		{
			set{ _teacher_tel=value;}
			get{return _teacher_tel;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string teacher_password
		{
			set{ _teacher_password=value;}
			get{return _teacher_password;}
		}
		#endregion Model

	}
}

