   M S B A M L   `   `   `  ����F  BPhotoEditor, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:PhotoEditor.ViewModelPhotoEditor.ViewModel  5   	   )clr-namespace:PhotoEditorPhotoEditor  5   	       PhotoEditor.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2vm#clr-namespace:PhotoEditor.ViewModel     5   	   +localclr-namespace:PhotoEditor     5   	     � Title$  
MainWindow��5	   	   $	��450��6   $	��800��6)   .��5
      �  � ColumnDefinitions 5   
   �� 5      $	��120 �6   �� 5      $��* �6   .+�5   
   �� $��0��6   $��0,0,0,0q�6&   $��Center=�67   $��Center=�6T   .+�5      �� $
��Load��6   $
��Left=�6D   $��0,10,0,0q�6_   $	��Top=�6q   $��40��6�   $��90��6�   ��6$   �� *LoadCommand+6�   �� 5      $��Edit 1��6   $
��Left=�6H   $��0,10,0,0q�6c   $	��Top=�6u   $��40��6�   $��90��6�   ��6&   �� *Edit_1Command+6�   �� 5      $��Edit 2��6   $
��Left=�6H   $��0,10,0,0q�6c   $	��Top=�6u   $��40��6�   $��90��6�   ��6&   �� *Edit_1Command+6�   �� 5      $��Button��6   $
��Left=�6&   $��0,10,0,0q�6A   $	��Top=�6S   $��40��6k   $��90��6w   �� 5      $��Button��6   $
��Left=�6&   $��0,10,0,0q�6A   $	��Top=�6S   $��40��6k   $��90��6w   5      �� 5   
   $��1��6   $��0,0,0,0q�6%   $��Center=�66   $��Center=�6S   .+�5      �� $
��Left=�6/   $	��410��6J   $��0,0,0,0q�6W   $	��549��6h   ��6   �� *	Picture+6h   5      5      5      