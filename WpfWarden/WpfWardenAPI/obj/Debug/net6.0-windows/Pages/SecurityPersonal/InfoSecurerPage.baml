   M S B A M L   `   `   `  ����G  CWpfWardenAPI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullY1clr-namespace:WpfWardenAPI.Pages.SecurityPersonal#WpfWardenAPI.Pages.SecurityPersonal  5      9    3WpfWardenAPI.Pages.SecurityPersonal.InfoSecurerPage   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Clocal1clr-namespace:WpfWardenAPI.Pages.SecurityPersonal     5      -   5          N� Title$  InfoSecurerPage��5	      .��5      � .+�5   
   �� $��40 30q�6   .@�5      �� $��Верификация��6   $��16(�6+   ��5      � 5       � RowDefinitions 5      �� 5      6.   �� 5      $��50 �6,   6:   .+�5      &   System.Windows.Controls.DataGrid  -   5          Name$ DGUsersForVerify��5   p      CanUserAddRows$ False��6#      CanUserDeleteRows$ False��6:      AutoGenerateColumns$ False��6T      
IsReadOnly$ False��6�      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5   "   ,  &System.Windows.Controls.DataGridColumn   Header$ Фамилия��65   	   
IsReadOnly$
	 True��6e   1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 6F   �� *
secondName+6e     5   "   $ Имя��65   $
	 True��6`   
 6B   �� *	firstName+6`     5   "   $ Отчество��65   $
	 True��6e   
 6G   �� *	thirdName+6e     5   "   $ Должность��65   $
	 True��6j   
 6H   �� *division.name+6j   4  .System.Windows.Controls.DataGridComboBoxColumn  5   "   -   5        CmbRole��$% Тип пользователя��5   u      DisplayMemberPath$
 name��6�      SelectedItemBinding 6J   �� *
permission+6�     5   "   $ 
Логин��65   
 6D   �� *login+  5   "   $ Пароль��65   
 6E   �� *
password+  5   "   $# Секретное слово��65   
 6N   �� *
secretWord+4  .System.Windows.Controls.DataGridCheckBoxColumn  5   "   $ Одобрить��69   
 6K   �� *
isVerify+6j   5(      �� 5)      -   5         ��Name$ 
btnConfirm��5)   .   $��1��6!   $��Одобрить��6[   6p   5*      5,      �� 5-      $��Доступ��6   $��16(�6&   $	��Top=�64   ��5.      � 5/       50      �� 51      6.   �� 52      $��50 �6,   6:   .+�54        -   5        $ DGPermissions��54   �   $ False��6#   $ False��6:   $ False��6T   $ False��6p    55        56   "   $ Код��65   $
	 True��6c   
 6B   �� *PermissionId+6c     57   "   $ Название��65   
 6G   �� *Name+  58   "   $% Добавлять данные��69   
 6S   �� *	AddData+6q     59   "   $# Изменять данные��69   
 6R   �� *
ChangeData+6s     5:   "   $' !Составлять отчёты��69   
 6T   �� *
MakeReport+6u     5;   "   $! Удалять данные��69   
 6Q   �� *
DeleteData+6r   5=      � 5>      $��1��6   $��Center=�6,    � ColumnDefinitions 5?      �� 5@   "   65   �� 5A   "   65   �� 5B   "   65   .+�5D      �� -   5        $ 	btnDelete��5D   5   $��0��6%   $��Удалить��6H   6t   �� 5E      -   5        $ btnSave��5E   5   $��1��6%   $��Применить��6F   $
��40 0q�6Z   6�   �� 5F      -   5        $ btnAdd��5F   5   $��2��6%   $��Добавить��6E   6o   5G      5H      5J      �� 5K      $=��7Заблокированные пользователи��6   $��16(�6<   ��5L      �� 5M      -	   5         ��Name$ LVBlockedUsers��5M      $
��Left=�67   $��Disabled=�6Y   ��5S      �� 5T      .R�5U   "   �� $	��680��6)   $��68��65   ._�5V   &   � $��8q�6+    5W   *   �� 5X   .   $��30 �6?   6L   �� 5Y   .   6A   .+�5[   *   �� ���#2247ff$��30��6F   $��30��6Q   $��Center=�6]    �� CornerRadius$ 15��6x   ��5\   .   �� 5]   2    �� 
TargetType" ��68   .�5^   6   ��  �� Property � y� �� Value$ Visible=�6S   6e    �� Triggers 5_   6   �� 5`   :    �� Binding 6F   �� *uncheckedMessagesCount+ �� Value 06q   .a�5a   >   ��  � y�$ Hidden=�6[   5b   ;   5d   3   ._�5f   .   �� $��14(�68   
�������$
��Bold"�6Y   $��Center=�6l    �� TextAlignment$ Center=�6�   ��6�   �� *uncheckedMessagesCount+��5g   2   �� 5h   6   " ��6<   .�5i   :   ��  � y�$ Visible=�6W   6i    5j   :   �� 5k   >    6J   �� *uncheckedMessagesCount+ 06u   .a�5l   B   ��  � y�$ 	Collapsed=�6_   5m   ?   5o   7   5q   /   5r   +   �� 5s   *    �� Orientation$ Vertical=�65   $��1��6L   $��4 0 0 0q�6\   .+�5t   .   �� $ 
Horizontal=�69   $��10 0 0 0q�6R   .+�5u   2   �� $��18(�6<   ���#2247ff��6_   �� *sendlerUser.secondName+6�   �� 5v   2   $��18(�6<   ���#2247ff$�� ��6_   6j   �� 5w   2   $��18(�6<   ���#2247ff��6_   �� *sendlerUser.firstName+6�   �� 5x   2   $��18(�6<   ���#2247ff$�� ��6_   6j   �� 5y   2   $��18(�6<   ���#2247ff��6_   �� *sendlerUser.thirdName+6�   �� 5z   2   $��18(�6<   ���#2247ff$	�� - ��6_   6l   �� 5{   2   $��18(�6<   ���#2247ff��6J   �� *sendlerUser.division.name+6�   5|   /   �� 5}   .   $ 
Horizontal=�69   $��2 2 0 0q�6R   .+�5~   2   �� ��5   6   �� 5�   :   " ��6@   .�5�   >   ��  � ��$   Вы: ��6U   6f    5�   >   �� 5�   B    6N   �� *#!userLastMessage.DestinationUserId+ 6�   Z� .a�5�   F   ��  � ��$  ��6]   5�   C   �� 5�   B    6N   �� *userLastMessage.Message+ 6z   Z� .a�5�   F   ��  � ��$  ��6]   5�   C   5�   ;   5�   3   �� 5�   2   ��5�   6   �� 5�   :   " ��6@   .�5�   >   ��  � �� 6U   �� *userLastMessage.Message+ �� StringFormat$
  {0}��6�    5�   >   �� 5�   B    6N   �� *userLastMessage.Message+ 6z   Z� .a�5�   F   ��  � ��$> 8 Пока что здесь нет сообщений...��6]   �� 5�   F    � �� �#5556r   5�   C   5�   ;   5�   3   5�   /   5�   +   5�   '   5�   #   5�      5�      5�      5�      �� 5�   
   -
   5         ��Name$ txtFIO��5�   g   $��Right=�6   $	��Top=�60   $��0 5 5 0q�6H   $��20(�6Y   6y   5�      5�      