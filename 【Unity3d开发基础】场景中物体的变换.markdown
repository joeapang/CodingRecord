# 【Unity3d开发基础】场景中物体的变换

标签（空格分隔）： Unity

---

##Transform与坐标系
在Unity中除了Unity4.6之后的UGUI的UIPanel之外，所有你在场景中添加的组件在*Inspector*中都会有一个*Transform*组件。这个组建中包含了场景中每个物体的位置（Position），旋转（Rotation）和比例（Scale）信息。
物体的Transform信息都是相对于它父物体的Transform信息。如果没有父物体，那么该物体的Transform信息都是相对与世界坐标的。





