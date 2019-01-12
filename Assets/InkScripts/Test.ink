INCLUDE Test2.ink

-> 1stPart
=== 1stPart ===
你好
我是Ink写出来的故事
TODO: 测试TODO的功能

*   Ink用起来怎么样呢
用起来很舒服
但是很遗憾，我使用 tag 的时候，貌似不能使用中文
-> 2ndPart
=== 2ndPart ===
*   [原来用\[\]包围选项就不会说出去了]
    是的
-> 3rdPart
=== 3rdPart ===
*   Ink还有什么功能？[我得详细问问]我问
Ink还可以在语句中->divert
=== divert ===
切换到其他的 knot
如果希望
<> 任意两句话连起来而不是分行
<> 可以使用 "\<\>" 符号
你还想接着学吗？
* 我想 ->branch
* 我很想 -> branch
* 我非常想 -> branch
=== branch ===
好，那我们继续吧
接下来我们将展示细分 knots 功能
请随意选择
* subdivided 的子节点1
-> subdivided.subdivided_1
* subdivided 的子节点2
-> subdivided.subdivided_2
* subdivided 的子节点3
-> subdivided.subdivided_3
* subdivided 的默认节点
-> subdivided
=== subdivided ===
= subdivided_1
    写作 \= subdivided_1
    -> endplot
= subdivided_2
    写作 \= subdivided_2
    -> endplot
= subdivided_3
    写作 \= subdivided_3
    -> endplot
= endplot
    内部跳转的话，可以不写明父节点
    也就是不需要写成 \-\> subdivided.endplot
    只需要写作 \-\> endplot
    也就是说，不同的 knots 的子节点可以使用相同的名字
    *   [继续]
    接下来我们将跳转到另一个文件
    使用 I\NCLUDE 命令
    *    *   [跳转到 Test2_1]
        -> Test2_1