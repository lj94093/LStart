   M S B A M L   `   `   `  ����A  =LStart, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:LStart.ControlsLStart.Controls  5      clr-namespace:LStartLStart  5          LStart.Controls.LeftList   5   
   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      /localclr-namespace:LStart.Controls     5      'lStartclr-namespace:LStart     5      $��12(�5	   7     � 	Resources  5
       �� 
TargetType �� Property �� Value �� 
TargetType   ScrollBar.Static.Thumb �� Color  ScrollBarThumbVertical ��Name J� SnapsToDevicePixels  
Background �Name	 ]�Name
 J� IsMouseOver ]� DecreaseRepeatButton �� PageUpCommand ]� IncreaseRepeatButton �� PageDownCommand ]� Thumb � ColumnDefinitions � RowDefinitions ��Name �� CanContentScroll �� CanHorizontallyScroll �� CanVerticallyScroll ��Name4  .System.Windows.Automation.AutomationProperties   AutomationId � Cursor �� ScrollableHeight � Maximum � Minimum* �� #ComputedVerticalScrollBarVisibility �� ViewportHeight �� ViewportSize � Value  �� Mode! �� RelativeSource  ContextMenu  	LoadGroup" S� 
ObjectType  LStart.UserConfig# S� 
MethodName  LeftListItemTemplate$ J� 	AllowDrop% �� DataType& � ContextMenu' �� Path( � FocusVisualStyle  LeftListItemStyle) �� Triggers* P� Property+ P� Value��%m  '��       &	  H    &	 k    7   '�� �    7  7  7  '��     &	     &	 �    &	 �    7  &	 �
    7  �� 5   
   " ��6   .�5      ��  �@�OverridesDefaultStyle . 66   �� 5       � ��
 ���� 6+   �� 5       � |� .  6*   �� 5       � �� .  6*   �� 5       � �� 5      �� 5      " ��6&   .R�5      �� #��z��6$   #��z��6H   #��z��6j   5      5      5      �� 5   
   $ 	#60aaaaaa��69   �� 5   
   " n�6/   .�5      ��  �@�OverridesDefaultStyle . 66   �� 5       � �� .  6*   �� 5       � �� 5      �� 5      " n�6&   .R�5       �� $ 	rectangle��6$   8��  #��z��6f    . #��z��6�   5!      5#      5$      �� 5%   
   " ��6   .�5&      ��  �@��IsPressAndHoldEnabled .  6=   �� 5'       �@��IsFlicksEnabled .  67   �� 5(       � ��8   6+   �� 5)       � ��8  6+   �� 5*       � ��$ 0q�60   �� 5+       � ��$ 7��6&   �� 5,       � ��$ 7��6)   �� 5-       � �� 5.      �� 5/      " ��6&   .R�50      � $ Bg��6    . .+�51      �� #��z��6%   #��z��6Q   #��z��6�   ]� 52      $	 
PART_Track��6$   ��. #{�z
 6S    53   "   �� 54   &   #��Z 63    56   "   �� 57   &   #��Z 63    59   "   n� 5:   &   8�� 6,   5<      5=      5>      5@      5A      �� 5B   
   " ��6   .�5C      ��  � �� 5D      �� 5E      " ��6&   .R�5F      � $
 Grid��6   #��z��6-    5G      �� 5H   "   $��* �63   �� 5I   "   $
��Auto �63    5K      �� 5L   "   $��* �60   �� 5M   "   $
��Auto �60   .+�5O      �� $ Corner��6(   $��1��68   #��� ��6H   $��1��6�   �� 5P      $! PART_ScrollContentPresenter��65   # z��6Z    .   .  #��z��6�   #��z��6�   $��0��6"  #��z��62  $��0��6U  �� 5Q      $ PART_VerticalScrollBar��6(   $ VerticalScrollBar��6H   $ Arrow��6~   $��1��6�   # z 6�   $ 0Q�6�   $��0��6�   #y�z 6�   # z 6�   6&  �� *VerticalOffset+$  OneWay=�! �� *TemplatedParent+6�  5R      5S      5U      5V      �� 5Y   
   .@�5Z      m� -   5        $��	重命名��5Z      6A   m� 5[      -   5        $��删除��5[      6D   5\      S� 5^   
   ""  6/   $# get_userGroups��6W   �� 5`   
   " ��67   .R�5b      �� -   5        #��z��5b      $ . ._�5c      �� ��5d      �� 5e      (��       6'   *lStart:UserGroup+)$% lStart:UserGroup��.R�5f      �� -   5        $��0q�5f   &   |�.  $ Arrow��6s   8&   
�������$��Center=�5m   I   $��Stretch=�6m   $��Center=�6�   ��5f   :   �� $
' name�$  TwoWay=���5g   &   Z� ( 5l   &   Z� .��5n   i   5o      5r      5u      5v      5w      �� 5y   
   " ��6*   .�5z      ��  � ��$ 0q�60   6<   �� 5{       � ��$ 30��6'   �� 5|       �@J�	AllowDrop . 69   �� 5}       � ��$ Center=�6;   �� 5       � ��8   6)   ) 5�      P� 5�      * �@��
IsSelected+ . . �5�      ��  � �� �	#FF2160A063   5�      5�      5�      ��5�      �� 5�   
   " ��6   .�5�      ��  � �� 6,   �� , �� Source#, [ 6b   �� 5�       � ��# [ 6,   6R   �� 5�       � ��# [ 6+   6Q   �� 5�       �@J�	AllowDrop . 69   �� 5�       � ��$ 0q�60   6<   �� 5�       � ��# [ 63   6`   5�      5�      