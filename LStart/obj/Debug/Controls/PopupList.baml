   M S B A M L   `   `   `  ����A  =LStart, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:LStart.ControlsLStart.Controls  5      clr-namespace:LStartLStart  5          LStart.Controls.PopupList   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      /localclr-namespace:LStart.Controls     5      'lStartclr-namespace:LStart     5        � 	Resources  5
         
LoadConfig S� 
ObjectType  LStart.UserConfig S� 
MethodName  ContextMenu   LStart.IconConverter  IconConverter    LStart.IconWeigthConverter  IconWeigthConverter%   LStart.IconColumnWidthConverter  IconColumnWidthConverter  RightListItemTemplate �� 
TargetType � ContextMenu � ToolTip �� Orientation �� DataType � ColumnDefinitions	 �� Source
 �� Path �� 	Converter  ViewItemStyle �� 
TargetType �� Property �� Value �� Triggers P� Property P� Value  ListViewControlTemplate ��Name �� Padding J� SnapsToDevicePixels �� Triggers �� 
TargetName ]� 
Conditions �� Property �� Value��%�	  &	        &	 4     &	 H    &	 [    &	 n    &	 �    7  7   7  7  7   7  &	 �    7   7  7  &	 �    S� 5   
   "  60   $ get_windowConfig��6X   �� 5   
   .@�5      m� -   5        $��以管理员权限运行��5      6D   m� 5      -   5        $��打开文件位置��5      6D   m� 5      -   5        $��编辑��5      6>   m� 5      -   5        $��删除��5      6@   5        5   
   6     5   
   6%     5   
   6*   �� 5   
   " ��68   .R�5      �� -   5        #��z��5      8    5      _� 5      .��5      �� $ Vertical=�6%   
�������.+�5      �� ��6(   �� *name+�� 5       ��6(   �� *path+�� 5!      $ 
Horizontal=�6)   .+�5"   "   �� $��启动次数:��6,   6;   �� 5#   "   ��6,   �� *
startTimes+6J   5$      5%      5&      ._�5(      �� ��5)      �� 5*      (��       6'   *lStart:Shortcut+)$ lStart:Shortcut��.R�5+      �  5,   "   �� 5-   &   ��67   �� 8	  $
 
IconWeight�8  6�   �� 5.   &   $��* �67   6C   .+�50   "   �� $��0��6(   ��68   �� $

 path�8  ��51   (   �� 8	  $
 
IconWeight�8  �� 52   "   $��1��6,   
���   �$��Center=�6j   ��6O   �� $

 name�6�   53      54      56      57      58      �� 5:   
   " ��6&   .�5;      ��  � ��$ 14(�6)   66   �� 5<       � �� 6'   �� 8	   $
 
IconWeight�8  6�   �� 5=       � ��$ 0q�60   6<   �� 5>       � ��$
 Left=�6;   6J   �� 5?       � ��$ Center=�69   6J   �� 5@       � ��8  6)    5A      P� 5B       �@J�IsMouseOver . . �5C      ��  � �� �	#CC91C2E463   �� 5D       � �� �	#CC91C2E464   5E      P� 5F       �@��
IsSelected . . �5G      ��  � �� �	#CC418BCA63   5H      5J      �� 5L   
   " ��6:   .R�5M      �� $ Bd��6   #��z��6!   #��z��6M   #��z��6�   $ 0q�6�    . ._�5N      �� |�.  #��z��61   .��5O      �� # z 6%   5P      5Q       5R      P� 5S       � {� .  . �5T      �� $ Bd��63    � ��
 �����6C   �� 5U      $ Bd��64    � �� �	#FFD9D9D96D   5V      ]� 5W       5X      �� 5Y       �@��
IsGrouping . 6:   �� 5Z      " �@%�IsVirtualizingWhenGrouping .  6\   ./�5\      ��  � �� .  6F   5]      5_      5`      ��5b      �� 5c   
   " ��6   .�5d      ��  � ��$ 0q�60   6<   �� 5e       � ��
 �����6;   �� 5f       �@��
IsSelected .  6;   �� 5h       � ��# [ 63   5i      5j      5l      