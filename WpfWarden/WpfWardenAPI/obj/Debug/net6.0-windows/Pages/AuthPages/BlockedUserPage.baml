   M S B A M L   `   `   `  ����G  CWpfWardenAPI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:WpfWardenAPI.Pages.AuthPagesWpfWardenAPI.Pages.AuthPages  5      2    ,WpfWardenAPI.Pages.AuthPages.BlockedUserPage   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      <local*clr-namespace:WpfWardenAPI.Pages.AuthPages     5      -   5          N� Title$  BlockedUserPage��5	      .��5      �  � ColumnDefinitions 5   
   �� 5      6!   �� 5      $��1 �6   6+   �� 5      $	��790 �6   6-   �� 5      $��1 �6   6+   �� 5      6!   .+�5   
   � $��1��6   
���   �64   � 5   
   $��3��6   
���   �64   � 5   
   $��2��6    � RowDefinitions 5      �� 5      6"   �� 5      $��50 �6    6.   .+�5      �� -   5         ��Name$ ScrollMessages��5      $��Disabled=�63   $��Hidden=�6\   .��5      �� .+�5       �� -   5         ��Name$ 
LVMessages��5    �   $��0q�6   $��0 0 0 1q�63   $	��790��6u    J� IsManipulationEnabled$ False��6�   ��5!      �� 5"      .R�5#   "   � $	��774��6'   ��5$   &   �� 5%   *    �� 
TargetType" �60   .�5&   .   ��  �� Property � y� �� Value$ Visible=�6K   6]   	 �� Triggers	 5'   .   �� 5(   2   
 �� Binding
 6>   �� *	Message+ �� Value null6Z   .a�5)   6   ��  � y�$ Hidden=�6S   5*   3   5,   +   .+�5.   &   �� $	��666��6-   
���iii�$��0q�6R   ��5/   *   �� 50   .   " ��64   .�51   2   ��  � ��$
 Left=�6X   6g   �� 52   2    �@��CornerRadius$ 
12 12 12 0��6Q   6f   �� 53   2    � �� �#a0d6ff6a   	 54   2   �� 55   6   
 6B   �� *SendlerUser.isBlocked+ True6l   .a�56   :   ��  � ��$ Right=�6`   57   7   �� 58   6   
 6B   �� *SendlerUser.isBlocked+ True6l   .a�59   :   ��  �@��CornerRadius$ 
12 12 0 12��6Y   5:   7   �� 5;   6   
 6B   �� *SendlerUser.isBlocked+ True6l   .a�5<   :   ��  � �� �#22aeff6W   5=   7   5?   /   ._�5A   *   � $��0 0 0 0q�6/    5B   .   �� 5C   2   6B   �� 5D   2   6B   .+�5F   .   �� $
��Wrap=�68   
���   �$��6 2 6 0q�6x   $��18(�6�   $��0��6�   ��6_   �� *	Message+��5G   2   �� 5H   6   " ��6<   .�5I   :   ��  �@��TextAlignment$
 Left=�6Z   6i   	 5J   :   �� 5K   >   
 6J   �� *SendlerUser.isBlocked+ True6t   .a�5L   B   ��  �@��TextAlignment$ Right=�6b   5M   ?   5O   7   5Q   /   �� 5R   .   $��12(�6h   $��Right=�6v   $��Bottom=�6�   $��1��6�   
���iii���68   �� *Time+ �� StringFormat$ 	{0:HH:mm}����5S   2   �� 5T   6   " ��6<   .�5U   :   ��  � ��$ 2 0 5 2q�6S   6e   	 5V   :   �� 5W   >   
 6J   �� *SendlerUser.isBlocked+ True6t   .a�5X   B   ��  � ��$ 5 0 4 2q�6[   5Y   ?   5[   7   5]   /   5^   +   5_   '   5`   #   5a      5c      5d      5e      �� 5f      $��3��6   $��0 1 0 1q�6"   $��Center=�6<   $��Center=�6Y   
���   �._�5g      �� $
}�True��6    �� Orientation$ 
Horizontal=�61   $��3��6J   .+�5h      �� -   5         ��Name$ btnDeleteMessage��5h      ���#2456ff���#ffffff$��48��6�   $��48��6�    � Cursor$
 Hand��6�   $
��🗑��6�   $��30(�6�   $��0q�6�   ��6�   Z� 5|      �� 5}      -   5         ��Name$ txbMessageText��5}   W   $��10 0 0 0q�6   ���#fff$��0q�6C   $	��694��6o   $��16(�6{   $��Center=�6�   6�   �� 5~      -   5        $ btnSendMessage��5~   l   $��	0 -6 0 -6q�6   
����������#2456ff$��0q�6X   $��Center=�6�   $��40(�6�   $��60��6�   $	��➤��6�   $��48��6�   6�   5      5�      5�      5�      5�      