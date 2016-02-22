using System;
namespace OnlineAcademicSystem.Model
{
	/// <summary>
	/// admin:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class admin
	{
		public admin()
		{}
		#region Model
		private string _admin_id;
		private string _admin_password;
		/// <summary>
		/// 
		/// </summary>
		public string admin_id
		{
			set{ _admin_id=value;}
			get{return _admin_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string admin_password
		{
			set{ _admin_password=value;}
			get{return _admin_password;}
		}
		#endregion Model

	}
}

