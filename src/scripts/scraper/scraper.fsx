
//

//    Basic Content Scraper - Youtube

//




#I "packages/Google.Apis/lib/net40/"
//#I "packages/Google.Apis/lib/portable-net40+sl50+win+wpa81+wp80/"
#I "packages/Google.Apis.Core/lib/portable-net40+sl50+win+wpa81+wp80/"
#I "packages/Newtonsoft.Json/lib/portable-net40+sl5+wp80+win8+wpa81/"
#I "packages/Microsoft.Net.Http/lib/portable-net45+win8+wpa81/"
#I "packages"

#r "Fsharp.Data/lib/net40/FSharp.Data.dll"
#r "Zlib.Portable/lib/portable-net4+sl5+wp8+win8+wpa81+MonoTouch+MonoAndroid/Zlib.Portable.dll"
#r "Newtonsoft.Json/lib/portable-net40+sl5+wp80+win8+wpa81/Newtonsoft.Json.dll"
#r "log4net/lib/net40-full/log4net.dll"
#r "Google.Apis/lib/net40/Google.Apis.dll"
#r "Google.Apis.Core/lib/portable-net40+sl50+win+wpa81+wp80/Google.Apis.Core.dll"
#r "Google.Apis.Auth/lib/net40/Google.Apis.Auth.dll"
#r "Google.Apis.YouTube.v3/lib/portable-net40+sl50+win+wpa81+wp80/Google.Apis.YouTube.v3.dll"
#r "Microsoft.Bcl.Async/lib/net40/Microsoft.Threading.Tasks.dll"
#r "Microsoft.Bcl.Async/lib/net40/Microsoft.Threading.Tasks.Extensions.dll"
#r "Octokit/lib/net45/Octokit.dll"



open System
open System.Runtime
open System.IO
open FSharp.Data
open FSharp.Data.JsonExtensions
open Google.Apis
open Google.Apis.Auth.OAuth2
open Google.Apis.Services
open Google.Apis.Util.Store
open Google.Apis.YouTube.v3
open Google.Apis.YouTube.v3.Data
open Octokit



type Settings = JsonProvider<"secrets.json">
let settings = Settings.Load("secrets.json")



type HighlightRepo() =

    let repoOwner, repoName = "octogoncontrol", "mmahighlights"
    
    let github = new Octokit.GitHubClient(
                            new ProductHeaderValue("HighlightPublishing"), 
                            Credentials = new Credentials(settings.GitHub.ClientSecret))   
    let repo = github.Repository.Content

    member private this.GetInfo filePath =
        let contents = 
            async { return repo.GetAllContents(repoOwner, repoName, filePath).Result } 
            |> Async.RunSynchronously 
        contents.[0]

    member this.Get filePath = (this.GetInfo filePath).Content |> Convert.FromBase64String

    member this.Update filePath encodedFileContents = 
        let targetFileInfo = this.GetInfo filePath
            
        let update = new UpdateFileRequest("Highlight auto update", encodedFileContents, targetFileInfo.Sha, 
                                           Committer = new Committer("Highlight Automation", "mmahighlights@example.com", new DateTimeOffset(DateTime.Now)))

        let updatedContent =  
            async { return repo.UpdateFile(repoOwner, repoName, filePath, update).Result } 
            |> Async.RunSynchronously
        ()





// Youtube integration

let init = new BaseClientService.Initializer(ApiKey = settings.YouTube.ClientSecret) // missing application name "highlight service"
let youtube = new YouTubeService(init)


let searchListRequest = youtube.Search.List("snippet,statistics")
searchListRequest.Fields = "items(id,snippet,statistics)"
searchListRequest.ChannelId = "UCnkMTsKYqhHm6l6GQzg4szg"
searchListRequest.Q = ""
searchListRequest.MaxResults = new Nullable<int64>(50L)


let searchListResponse =
    async {
        let response = searchListRequest.ExecuteAsync().Result
        printf "%O" (response)
    } |> Async.RunSynchronously




// grab some highlights from youtube
// push their info to a JSON file




// Highlights


type MmaSource =
  | ONE_FC
  | RFA
  | Legacy
  | KSW
  | BAMMA
  | Cage_Warriors
  | Jungle_Fight
  | Shooto
  | King_of_the_Cage
  | Titan_Fighting_Championship
  | Road_FC
  | WSOF
  | Bellator
  | AXS_TV

type MediaSource =
  | YouTube of string
  | Facebook
  | EmbeddedUrl

type Highlight = Highlight

type HighlightSource = MmaSource * MediaSource

let HighlightSources : HighlightSource list =
  [
     ONE_FC,    (YouTube "https://www.youtube.com/user/OneFCMMA")
     Bellator,  (YouTube "https://www.youtube.com/user/BellatorMMA")
     AXS_TV,    (YouTube "https://www.youtube.com/user/HDNetFights/videos")
     KSW,       (YouTube "https://www.youtube.com/user/KSW")
     BAMMA,     (YouTube "https://www.youtube.com/user/BAMMAUK")
  ]




// Crack the secrets file for the API Key value
// Hit up the API and start listing out videos?




// Chew through a list of feeds creating highlight playlists for each
  // pull up likes
  // synthesize
  // invidual filter [later]

// Pull fan videos

// Allow direct submissions
  // Of youtube videos
  // Of videos for access on the youtube channel
    // (tagged with producer for approval?)
  // Consider alternative hosting solutions here?
    // Essentially watchseries, plus plus







//.
