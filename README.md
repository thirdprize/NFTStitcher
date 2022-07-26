# NFTStitcher

This program allows you to composite different layers together to make an image.  It groups the images into layers and will generate an image for all combinations of layers.  For example if you were generationg PFP NFTs and had three base faces and three different hats.  This would generate all 9 combinations.

# Usage
To run the program use the following command line as an example
```dotnet nftstitcher.dll --inputFile:"C:\Users\user\Documents\Art\Crypto\nft" --outputFile:"C:\Users\user\Documents\Art\Crypto\nft\output\" --layers:body,eyes,mouth,nose,hair,accessory```
where

*--inputFile*
Is the folder with all your layers in.

*--outputFile*
Where the files are saved to

*--layers*
This is a comma seperated list of the various layer names.  The layer names form the basis of the image file names.  The "nose" layer would contain "nose-big.png", "nose-medium.png" and "nose-small.png".

I might add JSON metadata if anyone wants.
