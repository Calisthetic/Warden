   M S B A M L   `   `   `  ����D  @WpfWarden, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:WpfWarden	WpfWarden  5   	       WpfWarden.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:WpfWarden     5   	     � Title$  Warden��5   	   $	��720��6   $
��1080��6%   $	��480��62   $	��800��6B   .��5	      �  � RowDefinitions 5
   
   �� 5      $��50 �6   �� 5      $��* �6   .+�5   
   �  K� ZIndex$ 10��6    J� Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5         Opacity$	 0.7Q�6#      ShadowDepth$ 0Q�61      
BlurRadius$ 5Q�6A   .+�5      � ���#2267ff6*   �� 5      -   5         ��Name$ btnBack��5      ���#2247ff$��0 0 0 0q�6Q   
���   �$
��Left=�6   $	��0 0q�6�   $��50��6�   $��50��6�   $	��❮��6�   $��24(�6�   6�   �� 5      -   5         ��Name$ txtTitle��5   =   
�������$
��Bold"�6+   $��Warden��6O   $��Bahnschrift Light)�6]   $��Center=�6|   $��Center=�6�   $��30(�6�   6�   5       � 5   
   -   5        $��	MainFrame��5      $��1��6   	  � NavigationUIVisibility$	 Hidden=�6.   6|   5      5      