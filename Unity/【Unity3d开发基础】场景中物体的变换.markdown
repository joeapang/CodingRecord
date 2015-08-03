
# 【Unity3d开发基础】场景中物体的变换

标签（空格分隔）： Unity

---

##Transform与坐标系
在Unity中除了Unity4.6之后的UGUI的UIPanel之外，所有你在场景中添加的组件在*Inspector*中都会有一个*Transform*组件。这个组建中包含了场景中每个物体的位置（Position），旋转（Rotation）和比例（Scale）信息。
物体的Transform信息都是相对于它父物体的Transform信息。如果没有父物体，那么该物体的Transform信息都是相对与世界坐标的。例如：在场景中添加一个Cube，然后再添加一个Cube1作为Cube的子物体。我们对Cube进行旋转，位移，缩放等等操作时，对Cube1中的Transform组件中的信息是没有影响的。这是因为Cube1的Transform中的所有信息都相对与Cube的。
###坐标系
Unity中的常用坐标系有四种：

 - 世界坐标系
我们在场景中添加物体（如：Cube），他们就是以世界坐标系显示在场景中，我们可以用*tranform.position*来获取。
 - 屏幕坐标系
屏幕坐标系是以像素为单位的，以屏幕左下角为（0，0），右上角（scree.width，screen.height）。z的位置以相机的世界位置来衡量。

    screen.width=Camera.pixelWidth
    screen.height=Camera.pixelHeight


 - 视口坐标系
视口坐标是相对于相机的，相机的左下角为（0，0），右上角为（1，1），z的位置是以相机的世界位置来衡量的。
 - 绘制UI坐标系
这个坐标属于屏幕坐标的一种，不同的这个坐标以屏幕的左上角为（0，0），右下角为（screen.width，screen.height）。

###有关于坐标转换的方法
Unity中关于坐标转换的方法常用的有：

 - TransformPoint ()：把position从本地坐标转换为世界坐标
 - InverseTransformPoint ()：把position从世界坐标转换成本地坐标
 - TransformDirection ():把direction从本地坐标转换成世界坐标
 - InverseTransformDirection ():把direction从世界坐标转换成本地坐标
当我们的主角要搬运一个物体，比如在一个投篮游戏中，我们的主角要携带球，这个时候可以把球的世界坐标转换成相对与主角的本地坐标；然后主角把球抛出去，此时球的坐标集可以从本地坐标转换成世界坐标，并且把球抛出去的方向也是从本地坐标转换成世界坐标。


----------


    cube.transform.parent = transform;
    cube.transform.position = transform.TransformPoint (0,0,2);//把物体的世界坐标转换成本地坐标
    cube.GetComponent<Rigidbody> ( ).isKinematic = true;


----------


    cube.GetComponent<Rigidbody> ( ).isKinematic = false;
    
    //transform.TransformDirection ( 0, 0, 10 );把本地方向转换成世界方向，并沿着这个方向给物体一个冲量
    cube.GetComponent<Rigidbody> ().AddForce(transform.TransformDirection(0,0,10),ForceMode.Impulse);
    transform.DetachChildren ( );
    


----------
##物体的位移
Unity提供了Translate方法用来控制物体的位移。Translate方法有6种形式的重载。可以控制物体的移动方向，相对移动的坐标等属性。
当我们需要物体物体沿着一个方向向量进行移动时，可以这样做：
```
transform.Translate(new Vector(1,1,1)*speed*Time.deltaTime,Space.Self);
```
我们还可以同过AnimationCurve来指定物体的移动轨迹。从而控制物体的运动。关于AnimationCurve的知识会在另一篇文章介绍。这里不做深究。
```

public AnimationCurve animCurve;
void Update(){
this.transform.position =
            new Vector3 ( transform.position.x + 0.1f * Time.deltaTime, animCurve.Evaluate ( Time.time), transform.position.z );
        animCurve.Evaluate ( Time.time );
        }
```
##物体的基本旋转
Unity对于物体的旋转像我们提供了eluerAngles（欧拉角）和Quaternion（四元数）两种参数。

 - eluerAngles（欧拉角）


> 构件在三维空间中的有限转动，可依次用三个相对转角表示，即进动角、章动角和自旋角，这三个转角统称为欧拉角。——引自百度百科

欧拉角在我们的场景中用一个三维向量来表示，范围在（0.0，0.0，0.0）到（360.0，360.0，360.0）之间。在Unity中提供了两种欧拉角，localEluerAngles（本地欧拉角）和eluerAngles（世界欧拉角）。



在Unity中提供了一些方法用于物体的旋转：

 - Rotate( )：应用一个eulerAngles的欧拉角，旋转纵坐标系为relativeTo
 - RotateAround( )：以axis为轴按照angle度通过在世界坐标的point旋转物体。
 - LookAt( )：旋转物体，使得向前的向量（z轴）指向target当前位置
对于Rotate方法，同样有6中重载方法，用来控制物体的旋转角度，旋转轴，相对旋转坐标，旋转的速度。
如我们让物体绕着Y轴每秒旋转45度
```
this.transform.Rotate ( new Vector3(0,45,0)*Time.deltaTime, Space.World );
```
对于RotateAround方法有两个重载方法，对于RotateAround（Vector，float）方法，在编译的时候会提示已过期，建议用Rotate方法代替。
当我们想要物体绕着一个点或者物体的某个轴每秒旋转45度的时候，可以这样：
```
transform.RotateAround ( new Vector3 ( 2, 2, 2 ), Vector3.up,45 * Time.deltaTime );
```
LookAt方法可以让我们场景中的物体的z轴面向我们指定的位置。例如我们想要我们的摄像机时时锁定我们的某个物体，就可以用这个方法。
```
transform.LookAt(target.transform.position);
```

 - Quaternion（四元数）
四元数是为了解决Unity中的一些3D旋转所带来的各种麻烦，最有代表性的就是GimbalLock（万象节死锁）。所谓的万向节死锁是指在物体的旋转过程中三个万向节的其中两个轴发生重合时，失去一个旋转自由度的情形。详细可以参见视频[欧拉旋转][1]。
打开官网的API可以发现Quaternion中的Variables中有w，x，y，z四个变量。其实一个四元数就是由w，x，y，z构成的。其原理是参考数学中的复数。复数是形如a+b*i的由实部a加虚部b*i的数。而四元数是最简单的超复数，相似的四元数是由一个实部加上三个虚部构成的。w就是实部，x，y，z是虚部单位。其中x^2=y^2=z^2=-1。值得一提的是w，x，y，z四个数的取值范围都是[-1,1]，物体旋转两周，所有的数值才会回归初始值。假如初始值为（0，0，0，1），沿着y轴旋转：180°(0,1,0,0)， 360°（0,0,0,-1），540°(0,-1,0,0) ，720°(0,0,0,1)。


----------
现在我们来看一下Quaternion的函数都有什么用处。

 - LookRoation( )：静态函数，创造一个有明确的forward和upward方向的旋转。与成员函数SetLookRotation（）相似。
 - FromToRotation（）：创建一个旋转方向为fromDirection到toDirection的旋转。
 - RotateTowards（）：以maxDegreesDelta的速度从from旋转到to。


  [1]: http://v.youku.com/v_show/id_XNzkyOTIyMTI=.html