using System;
namespace OnlineAcademicSystem.Model
{
	/// <summary>
	/// major:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class major
	{
		public major()
		{}
		#region Model
		private string _major_id;
		private string _major_name;
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
		public string major_name
		{
			set{ _major_name=value;}
			get{return _major_name;}
		}
		#endregion Model

	}
}

