using System;
namespace OnlineAcademicSystem.Model
{
	/// <summary>
	/// teacher_position:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class teacher_position
	{
		public teacher_position()
		{}
		#region Model
		private string _teacher_position_id;
		private string _teacher_position_name;
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
		public string teacher_position_name
		{
			set{ _teacher_position_name=value;}
			get{return _teacher_position_name;}
		}
		#endregion Model

	}
}

