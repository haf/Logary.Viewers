open Hopac
open System
open Logary
open Logary.Configuration
open Logary.Internals
open Logary.Ingestion
open Suave
open Suave.Filters
open Suave.Operators

let app next =
  choose [
    path "/i" >=> HTTP.api HTTP.defaultConfig next
    path "/o" >=> HTTP.api HTTP.defaultConfig next
    RequestErrors.NOT_FOUND "Not found"
  ]

[<EntryPoint>]
let main argv =
  let next
  startWebServer defaultConfig app
  0