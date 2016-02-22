using System;
namespace OnlineAcademicSystem.Model
{
	/// <summary>
	/// classroom:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class classroom
	{
		public classroom()
		{}
		#region Model
		private string _classroom_id;
		private string _course_id;
		private string _classroom_name;
		/// <summary>
		/// 
		/// </summary>
		public string classroom_id
		{
			set{ _classroom_id=value;}
			get{return _classroom_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string course_id
		{
			set{ _course_id=value;}
			get{return _course_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string classroom_name
		{
			set{ _classroom_name=value;}
			get{return _classroom_name;}
		}
		#endregion Model

	}
}

