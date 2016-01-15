



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
