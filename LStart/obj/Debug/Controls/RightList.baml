   M S B A M L   `   `   `  ����A  =LStart, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:LStart.ControlsLStart.Controls  5      clr-namespace:LStartLStart  5          LStart.Controls.RightList   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      /localclr-namespace:LStart.Controls     5      'lStartclr-namespace:LStart     5         ListViewControlTemplate#���   5	   7     � 	Resources  5
        
LoadConfig S� 
ObjectType  LStart.UserConfig S� 
MethodName  ContextMenu   LStart.IconConverter  IconConverter    LStart.IconWeigthConverter  IconWeigthConverter%   LStart.IconColumnWidthConverter  IconColumnWidthConverter  RightListItemTemplate �� 
TargetType � ContextMenu � ToolTip �� Orientation �� DataType � ColumnDefinitions	 �� Source
 �� Path �� 	Converter  ViewItemStyle �� 
TargetType �� Property �� Value �� Triggers P� Property P� Value ��Name �� Padding J� SnapsToDevicePixels �� Triggers �� 
TargetName ]� 
Conditions �� Property �� Value��%0	  &	       &	 4     &	 H    &	 [    &	 n    &	 �    7  7  7  7  7  7  &	 �    7  7  7  &	  �    S� 5   
   "  60   $ get_windowConfig��6X   �� 5   
   .@�5      m� -   5        $��以管理员权限运行��5      6D   m� 5      -   5        $��打开文件位置��5      6D   m� 5      -   5        $��编辑��5      6>   m� 5      -   5        $��删除��5      6@   5        5   
   6     5   
   6%     5   
   6*   �� 5   
   " ��68   .R�5      �� -   5        #��z��5      8    5      _� 5      .��5       �� $ Vertical=�6%   
�������.+�5!      �� ��6(   �� *name+�� 5"      ��6(   �� *path+�� 5#      $ 
Horizontal=�6)   .+�5$   "   �� $��启动次数:��6,   6;   �� 5%   "   ��6,   �� *
startTimes+6J   5&      5'      5(      ._�5*      �� ��5+      �� 5,      (��       6'   *lStart:Shortcut+)$ lStart:Shortcut��.R�5-      �  5.   "   �� 5/   &   ��67   �� 8	  $
 
IconWeight�8  6�   �� 50   &   $��* �67   6C   .+�52   "   �� $��0��6(   ��68   �� $

 path�8  ��53   (   �� 8	  $
 
IconWeight�8  �� 54   "   $��1��6,   
���   �$��Center=�6j   ��6O   �� $

 name�6�   55      56      58      59      5:      �� 5<   
   " ��6&   .�5=      ��  � ��$ 14(�6)   66   �� 5>       � �� 6'   �� 8	   $
 
IconWeight�8  6�   �� 5?       � ��$ 0q�60   6<   �� 5@       � ��$
 Left=�6;   6J   �� 5A       � ��$ Center=�69   6J   �� 5B       � ��8  6)    5C      P� 5D       �@J�IsMouseOver . . �5E      ��  � �� �	#CC91C2E463   �� 5F       � �� �	#CC91C2E464   5G      5I      �� 5K   
   " ��6:   .R�5L      �� $ Bd��6   #��z��6!   #��z��6M   #��z��6�   $ 0q�6�    . ._�5M      �� |�.  #��z��61   .��5N      �� # z 6%   5O      5P       5Q      P� 5R       � {� .  . �5S      �� $ Bd��63    � ��
 �����6C   �� 5T      $ Bd��64    � �� �	#FFD9D9D96D   5U      ]� 5V       5W      �� 5X       �@��
IsGrouping . 6:   �� 5Y      " �@%�IsVirtualizingWhenGrouping .  6\   ./�5[      ��  � �� .  6F   5\      5^      5_      ��5a      �� 5b   
   " ��6   .�5c      ��  � ��$ 0q�60   6<   �� 5d       � ��
 �����6;   �� 5e       �@��
IsSelected .  6;   �� 5g       � ��# [ 63   5h      5i      5k      