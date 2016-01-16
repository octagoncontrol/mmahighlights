

(* Basic Content Scraper - Youtube *)


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
