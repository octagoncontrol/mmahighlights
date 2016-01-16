(*

    Basic Content Scraper - Youtube

*)


// Self contained reference management - paket

open System
open System.IO

Environment.CurrentDirectory <- __SOURCE_DIRECTORY__

if not (File.Exists "paket.exe") then
    let url = "https://github.com/fsprojects/Paket/releases/download/2.44.4/paket.exe"
    use wc = new Net.WebClient()
    let tmp = Path.GetTempFileName()
    wc.DownloadFile(url, tmp);
    File.Move(tmp,Path.GetFileName url)

#r "paket.exe"

Paket.Scripting.Install """
    source https://nuget.org/api/v2
    nuget Suave 0.16.0
    nuget FSharp.Data
    nuget FSharp.Charting
""";;





//


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
