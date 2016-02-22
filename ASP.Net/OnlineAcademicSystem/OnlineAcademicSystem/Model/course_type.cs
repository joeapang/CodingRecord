using System;
namespace OnlineAcademicSystem.Model
{
	/// <summary>
	/// course_type:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class course_type
	{
		public course_type()
		{}
		#region Model
		private string _course_type_id;
		private string _course_type_name;
		/// <summary>
		/// 
		/// </summary>
		public string course_type_id
		{
			set{ _course_type_id=value;}
			get{return _course_type_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string course_type_name
		{
			set{ _course_type_name=value;}
			get{return _course_type_name;}
		}
		#endregion Model

	}
}

