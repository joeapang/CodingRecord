using System;
namespace OnlineAcademicSystem.Model
{
	/// <summary>
	/// classes:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class classes
	{
		public classes()
		{}
		#region Model
		private string _class_id;
		private string _grade_id;
        private string _major_id;
		private string _class_name;
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
		public string grade_id
		{
			set{ _grade_id=value;}
			get{return _grade_id;}
		}
        public string major_id
        {
            set { _major_id = value; }
            get { return _major_id; }
        }
		/// <summary>
		/// 
		/// </summary>
		public string class_name
		{
			set{ _class_name=value;}
			get{return _class_name;}
		}
		#endregion Model

	}
}

