INCLUDE Test3_Variable.ink

=== Test2_1 ===
*   [继续]
现在你已经进入了 Test2.ink 的部分
接下来我们来看看选项的特殊用法
*   *   [继续]
所有的选项都只能被选择一次
这样，当没有选项时，将会出现错误
-> Fallback_choices
=== Fallback_choices ===
下面将展示如何解决这种错误
-> Fallback_choices_1
= Fallback_choices_1
这是选择示例
你第一次作出的选项将不能再次被选择
不论选项1还是选项2
最后都会重新回到这个节点的开始
*   选项1
    -> Fallback_choices_1
*   选项2
    -> Fallback_choices_1
*   ->
    当没有选项可供使用时
    这个不显示的选项就会生效
    它可以写作 "*	\-> \out_of_options"
    也可以直接写作 "* 	\-> "
*   *   [继续]
    -> Sticky_choices
=== Sticky_choices ===
但是只显示一次的选项
有时并不满足我们的需求
下面将展示可以重复进行选择的选项
*   [继续]
-> Sticky_choices1
= Sticky_choices1
这又是一个循环节点
我们有三个选项，分别是只能选择一次的，可以重复选择的，以及退出节点用的选项
*   [只能选择一次的]
    这是只能选择一次的选项
    点击继续会回到该节点的开头
    同时这个选项会消失
*   *   [继续]
    -> Sticky_choices1
+   [可重复选择的]
    该选项写作 "\+   可重复选择的"
    只是用 "\+" 代替 "\*" 即可
*   *   [继续]
    -> Sticky_choices1
*   [退出节点并进入下一部分]
    -> Conditional_Choices
=== Conditional_Choices ===
接下来我们来看看条件选项
+   {not Conditional_Choices1} [1.当你没有选过这个选项时，该选项才会出现]
    这个选项写作\+   \{\not \Conditional_Choices1\} [1.当你没有选过这个选项时，该选项才会出现]
    -> Conditional_Choices1
+   {Conditional_Choices1} [2.当你选过选项1以后，这个选项才会出现]
    这个选项写作\+   \{\Conditional_Choices1\} [2.当你选过选项1以后, 这个选项才会出现]
    -> Conditional_Choices2
+   {Conditional_Choices1} {Conditional_Choices2} [3.当你选过选项1和2以后，这个选项才会出现]
    这个选项写作\+   \{Conditional_Choices1\} \{Conditional_Choices2\} [3.当你选过选项1和2以后，这个选项才会出现]
    -> Conditional_Choices3
= Conditional_Choices1
*   [继续]
    -> Conditional_Choices
= Conditional_Choices2
*   [继续]
    -> Conditional_Choices
= Conditional_Choices3
    如果这是你第一次选择该选项，请再选择一次
*   [继续]
    -> Conditional_Choices
*   {Conditional_Choices3 > 1} [当你多次进入该节点后，这个选项将会出现]
    这个选项写作\*   \{Conditional_Choices3 > 1\} [当你多次进入该节点后，这个选项将会出现]
    条件选项的内容基本结束了
    接下来将介绍 Variable Text
*   *   [进入下一部分]
    -> Variable_Text
-> END