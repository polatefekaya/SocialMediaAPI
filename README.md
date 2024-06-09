![RosanicBannerJpg](https://github.com/polatefekaya/SocialMediaAPI/assets/65048297/498eb6d5-472a-4a26-b51f-b96f0b68e7b7)

# Welcome to **Rosanic** Social Media API

> You can create your own social media with this repository. Fork it and pull to your local machine

## Functionalities
### Account
- Register
- Login
- Logout
- Forgot Password
- Reset Password
- Two Factor Auth (using Twilio Sendgrid)
- E-Mail Verification (using Twilio Sendgrid)

### Sharing
#### Post
- Add
- Delete
- Update
- Get
- Get All By User
- Delete All By User
- Delete Batch

#### Comment
> You can only add comments to posts right now.
- Add
- Get
- Get All By User
- Get All By Post
- Delete
- Update
- Delete All By User
- Delete All By Post

### Like
#### Post and Comment
- Add
- Get
- Get All By Comment
- Get All By Post
- Get All By User
- Delete
- Delete All By User
- Delete All By Post (Deletes Given Post's All Likes)
- Delete All By Comment (Deletes Given Comment's All Likes)

### Follow
- Add
- Get Is Follow
- Get Followings
- Get Followers
- Delete
- Delete All By User

### User Block
- Add
- Get
- Get All By User
- Delete
- Delete All By User

### User Info
#### Base and Detailed
- Add
- Get
- Update
- Delete

# How To Use
## Start Migration
- Firstly, you have to set database. In the API Project, appsettings.json. 
- Set Connection String to your Database Conn String.
- Don't forget to change Jwt variables in appsettings.Development.json especially the Key.
- **Migrate with the commands that I pre wrote in the Infrastructure Project>MigrationCommands.xml**

## Change EMail Settings
- In the API Project>appsettings.json, you can change the Twilio Sendgrid settings little bit (Dynamic Template Ids and Sender Name)
- ApiKey must be supplied from environment variables via User-Secrets

## Change Logging
- In the API Project>appsettings.json and appsettings.Development.json, you can change the logging levels.

## Configure Launch Settings
- In the API Project>Properties>launchSettings.json, configure the options with your needs.
- App is in development mode as standard but you can change it.
- App will start with swagger UI but you can also change it.
