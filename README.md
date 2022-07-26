# NFTStitcher

This program allows you to composite different layers together to make an image.  It groups the images into layers and will generate an image for all combinations of layers.  For example if you were generationg PFP NFTs and had three base faces and three different hats.  This would generate all 9 combinations.

# Usage
To run the program use the following command line as an example
```dotnet nftstitcher.dll --inputFile:"C:\Users\user\Documents\Art\Crypto\nft" --outputFile:"C:\Users\user\Documents\Art\Crypto\nft\output\" --layers:body,eyes,mouth,nose,hair,accessory --fileName:Ted"```
where

*--inputFile* Is the folder with all your layers in.

*--outputFile*  Where the files are saved to.

*--layers* This is a comma seperated list of the various layer names.  The layer names form the basis of the image file names.  The "nose" layer would contain "nose-big.png", "nose-medium.png" and "nose-small.png".

*--fileName* Optional.  This is the prefix for the names of your output files.  Defaults to "NFT" giving you "NFT #20.png".

In the output folder there is a subfolder for each of the different base layers.  In the above example each "body" would have its own folder.  The files are saved in the format "ted #0.png" where the number is a sequential count of the number of files generated.

I might add JSON metadata if anyone wants.
