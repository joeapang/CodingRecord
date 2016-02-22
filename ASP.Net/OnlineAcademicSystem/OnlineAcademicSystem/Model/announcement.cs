using System;
namespace OnlineAcademicSystem.Model
{
	/// <summary>
	/// announcement:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class announcement
	{
		public announcement()
		{}
		#region Model
		private int _announcement_id;
		private string _announcement_content;
		private string _announcement_title;
		private string _announcement_attachment;
        private string _announcement_time;
		/// <summary>
		/// 
		/// </summary>
		public int announcement_id
		{
			set{ _announcement_id=value;}
			get{return _announcement_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string announcement_content
		{
			set{ _announcement_content=value;}
			get{return _announcement_content;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string announcement_title
		{
			set{ _announcement_title=value;}
			get{return _announcement_title;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string announcement_attachment
		{
			set{ _announcement_attachment=value;}
			get{return _announcement_attachment;}
		}
        public string announcement_time
        {
            set { _announcement_time = value; }
            get { return _announcement_time; }
        }
		#endregion Model

	}
}

