//Built with F# 1.9.7.8
open System.IO
open System.Net
open Microsoft.FSharp.Control.WebExtensions
//Add references for the namespaces below if you're not running this code in F# interactive
open System.Drawing 
open System.Windows.Forms 

let buildGoogleChartUri input =
    let chartWidth, chartHeight = 250,100

    let labels,data = List.unzip input
    let dataString = 
        data 
        |> List.map (box>>string) //in this way, data can be anything for which ToString() turns it into a number
        |> List.toArray |> String.concat ","

    let labelString = labels |> List.toArray |> String.concat "|"

    sprintf "http://chart.apis.google.com/chart?chs=%dx%d&chd=t:%s&cht=p3&chl=%s"
            chartWidth chartHeight dataString labelString

//Bake a bitmap from the google chart URI
let buildGoogleChart myData =
    async {
        let req = HttpWebRequest.Create(buildGoogleChartUri myData)
        let! response = req.AsyncGetResponse()
        return new Bitmap(response.GetResponseStream())
    } |> Async.RunSynchronously

//invokes the google chart api to build a chart from the data, and presents the image in a form
//Excuse the sloppy winforms code
let test() =
    let myData = [("John",34);("Sara",30);("Will",20);("Maria",16)]

    let image = buildGoogleChart myData
    let frm = new Form()
    frm.BackgroundImage <- image
    frm.BackgroundImageLayout <- ImageLayout.Center
    frm.ClientSize <- image.Size
    frm.Show()

test()