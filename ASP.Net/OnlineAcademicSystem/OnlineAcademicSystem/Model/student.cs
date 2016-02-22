using System;
namespace OnlineAcademicSystem.Model
{
	/// <summary>
	/// student:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class student
	{
		public student()
		{}
		#region Model
		private string _student_id;
		private string _grade_id;
		private string _class_id;
		private string _major_id;
		private string _student_name;
		private bool _student_sex;
		private string _student_tel;
		private string _student_places;
		private string _student_password;
		/// <summary>
		/// 
		/// </summary>
		public string student_id
		{
			set{ _student_id=value;}
			get{return _student_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string grade_id
		{
			set{ _grade_id=value;}
			get{return _grade_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string class_id
		{
			set{ _class_id=value;}
			get{return _class_id;}
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
		public string student_name
		{
			set{ _student_name=value;}
			get{return _student_name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool student_sex
		{
			set{ _student_sex=value;}
			get{return _student_sex;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string student_tel
		{
			set{ _student_tel=value;}
			get{return _student_tel;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string student_places
		{
			set{ _student_places=value;}
			get{return _student_places;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string student_password
		{
			set{ _student_password=value;}
			get{return _student_password;}
		}
		/// <summary>
		/// 
		/// </summary>
		#endregion Model

	}
}

