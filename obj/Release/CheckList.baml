   M S B A M L   `   `   `  ���� G  CScoreGraphV2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:ScoreGraphV2ScoreGraphV2      ScoreGraphV2.CheckList   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     ,localclr-namespace:ScoreGraphV2       � 	Resources  !  ScoreGraphV2.ColorConverter   ColorConverter�� %   &	          .���  � ColumnDefinitions �� $��* ��� $��3* ��� $��3* ��� $��3* ��� $��3* ��� $��* � � RowDefinitions �� $��40 ��� $��60 ��� $��* ��� $��60 �.+��� $��1��$��0��$��4��$��1��._��� $��训练成绩展示�����#000$��20(�$��Center=�$��Center=��� $��1�� �� Orientation$ 
Horizontal=�$��1��$��4��$��Center=�.+��� $��姓名��$��Center=�$��16(��� -    ��Name$ 
Users_Name��$	��100��$��20��$��Center=�$��Right=�$��0,0,10,0q��� $��训练科目��$��Center=�$��16(��� -    ��Name$ ProjectComboBox��$
��Left=�$
��Auto��$��3q�$��0��$��Center=�$	��100������ .R�$� �� -   ���#2862AD$��30��$��80�� �� CornerRadius$ 2,2,2,2�� � Cursor$
 Hand��$��	30,0,10,0q�._��� $��查询��$��16(����#fff$��Center=�$��Center=��� -   ���#2862AD$��30��$	��100��$ 2,2,2,2��$
 Hand��$��	30,0,10,0q�._��� $��查询全部��$��16(����#fff$��Center=�$��Center=�&   System.Windows.Controls.DataGrid  -     Name$ 	dataGrid1��$��1��$��2��$��4��	   CanUserAddRows	 .  
   AutoGenerateColumns
 .     ColumnHeaderHeight$ 40Q�
������    SelectionMode$ Single=�$��Hidden=�$��Hidden=�����  �� 
TargetType"  .���  �� Property �@ HeadersVisibility �� Value$ Column=���   �@ HorizontalGridLinesBrush ��  �� Color$
 #333�� �� Opacity$	 0.2Q���  �@ VerticalGridLinesBrush �� $
 #333��$	 0.2Q�   ColumnHeaderStyle �� =  7System.Windows.Controls.Primitives.DataGridColumnHeader"  .���  � �� �#E1F1FF��  � �� �#000��  � ��$ Center=���  � �� �� $
 #333��$	 0.2Q�   RowStyle �� )  #System.Windows.Controls.DataGridRow"  .���  � ��$ 0q� �� Triggers P�  P� Property �@J�IsMouseOver P� Value . . ���  � �� �� $ #E1F1FF��$ 1Q�P�  �@ 
IsSelected . . ���  � ��
 �  ��   	CellStyle �� *  $System.Windows.Controls.DataGridCell"  .���  � ��$ 0q� P�  �@ 
IsSelected . . ���  � �� �� $ AntiqueWhite��$	 0.9Q���  � ��
 �  ��   Columns 4  .System.Windows.Controls.DataGridTemplateColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ 编号��   Width5  /System.Windows.Controls.DataGridLengthConverter$ 50    CellTemplate �� .R��� $��Center=�$��Center=�.+��� ���� *Id+  $ 姓名��$ *  �� .R��� $��Center=�$��Center=�.+��� ���� *Name+  $ 科目��$ *  �� .R��� $��Center=�$��Center=�.+��� ���� *	Project+  $ 分数��$ 50  �� .R��� $��Center=�$��Center=�.+��� ���� *Score+����  �� Source# [    $ 时间��$ *  �� .R��� $��Center=�$��Center=�.+��� ���� *Time+  $ 操作��$ *  �� .R��� $ 
Horizontal=�$��Center=�$��40��.+���  ��Name$ 
borderEdit��-   $��Center=�$��Center=�._��� $��用户曲线图��$��14(�$��Center=�$
 Hand���� $ borderDelete��-   $��Center=�$��Center=�$
 Hand��._��� $��删除��$��14(�$��Center=��� $��1��$��3��._��� -    ��Name$ count��$��16(�$��Center=�$��Center=��� $��3��$��3��$ 
Horizontal=�$��Center=�$��30��.+��� -	   $��
Img\L1.png��$��20��$��20��$��Center=�$
 Hand���� -
   $��
Img\L2.png��$��20��$��20��$��Center=�$
 Hand���� -   $ CurrentPage��$��1��
���  ��$��12(�$��18��$��30��$��Center=�$
 Hand���� -   $ CurrentPage2��$��1��$��12(�$��18��$��30��$��Center=�$
 Hand���� -   $ CurrentPage3��$��1��$��12(�$��18��$��30��$��Center=�$
 Hand���� $
��....��$��12(�$��18��$��30��$��Center=�$
 Hand���� -   $ MaxPage��$��12(�$��18��$��30��$��Center=�$
 Hand���� -   $��
Img\R2.png��$��20��$��20��$
 Hand���� -   $��
Img\R1.png��$��20��$��20��$
 Hand���� $��4��$��3��._��� $��转到         页��$��16(�$��Center=�$
��Left=�$��	15,0,15,0q��� $��4��$��3��._��� -   $
 Page��$��30��$��30��$��16(� �� IsInputMethodEnabled .    �� TextAlignment$  Center=�$��	45,0,80,0q�$��Center=��� $��4��$��3��$��Center=�$��Right=�._��� -   $��确定��$��50��$��30��$��16(�$��Center=�