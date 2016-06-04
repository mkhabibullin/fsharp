// Learn more about F# at http://fsharp.org
// See the 'F# Tutorial' project for more help.
open FSharp.Charting
open System
open System.Windows.Forms

open System.Drawing

//[<EntryPoint>]
//[<STAThread>]
//let main argv = 
//    printfn "%A" argv
////    let f = (Chart.Line [ for x in -100 .. 100 -> x, pown x 3]).ShowChart()
////    System.Windows.Forms.Application.Run(f)
////    0 // return an integer exit code
//    
//    let n = 16
//    let point i =
//        let t = float(i % n) / float n * 2.0 * System.Math.PI in (sin t, cos t)
//    
//    let f = (Chart.Combine(seq { for i in 0..n-1 do for j in i+1..n -> Chart.Line [point i; point j] })
//    |> Chart.WithTitle(Text="Artistic FSharp.Charting Sample 1",Color=Color.DarkBlue,Style=ChartTypes.TextStyle.Frame)
//    |> Chart.WithYAxis(Enabled=false)
//    |> Chart.WithXAxis(Enabled=false)).ShowChart()
//    System.Windows.Forms.Application.Run(f)
//    0


open System.Windows.Forms.DataVisualization.Charting

[<EntryPoint>]
[<STAThread>]
let main argv = 
    printfn "%A" argv
    // Create an instance of chart control and add main area
    let chart = new Chart(Dock = DockStyle.Fill)
    let area = new ChartArea("Main")
    chart.ChartAreas.Add(area)

    // Show the chart control on a top-most form
    let mainForm = new Form(Visible = true, TopMost = true,  Width = 700, Height = 500)
    mainForm.Controls.Add(chart)
    System.Windows.Forms.Application.Run(mainForm)
    0
