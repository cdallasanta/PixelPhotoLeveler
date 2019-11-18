# PixelPhotoLeveler

Move all files in a tree up and into the parent directory, deleting the now empty subfolders as it goes.

The inspiration for this was taking photos on the Google Pixel. When taking a picture in portrait mode, the phone saves the original
photo and edited picture in their own subfolder. That works fine for the phone's own apps, but doesn't play well with third-party software.

## General Usage

Run the program, and input the absolute path to the folder you want leveled.

```
> What is the path to the folder you would like leveled?
> e.g.: C:\Users\<Username>\Pictures
D:\Pixel 3a\Internal shared storage\DCIM\Camera
```

Note: Newer phones do not connect with a drive letter, so this is not yet a perfect solution for the Google Pixel, but you can at least
create a local copy of the photos folder, level it, then copy it back in.
