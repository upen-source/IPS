namespace Entities.Test

open NUnit.Framework
open FsUnit
open Entities.Test.ModeratorFeePaymentStub

module ModeratorFeePaymentTest =

    [<Test>]
    let ``Payment should compute fee correctly depending on the patient earnings`` () =
        let payment = contributoryPaymentStub(10.0, 100.0)
        payment.ComputeFee() |> should equal 15.0

    [<Test>]
    let ``Payment should compute total pay correctly with less than 2 minimum earnings`` () =
        let payment = contributoryPaymentStub(10.0, 100.0)
        payment.ComputePayment() |> should equal 150
        payment.WasMaxApplied |> should be False

    [<Test>]
    let ``Payment should not overpass maximum value with less than 2 minimum earnings`` () =
        let payment = contributoryPaymentStub(5_000.0, 1_000_000.0)
        payment.ComputePayment() |> should equal 250_000
        payment.WasMaxApplied |> should be True

    [<Test>]
    let ``Payment should compute total pay correctly with earnings between 2 and 5 minimum earnings`` () =
        let payment = contributoryPaymentStub(2.0, 2_000_000.0)
        payment.ComputePayment() |> should equal 800_000
        payment.WasMaxApplied |> should be False

    [<Test>]
    let ``Payment should not overpass maximum value with earnings between 2 and 5 minimum earnings`` () =
        let payment = contributoryPaymentStub(60_000.0, 4_000_000.0)
        payment.ComputePayment() |> should equal 900_000
        payment.WasMaxApplied |> should be True

    [<Test>]
    let ``Payment should compute total pay correctly with earnings more than 5 minimum earnings`` () =
        let payment = contributoryPaymentStub(1.0, 4_700_000.0)
        payment.ComputePayment() |> should equal 1_175_000
        payment.WasMaxApplied |> should be False

    [<Test>]
    let ``Payment should not overpass maximum value with earnings more than 5 minimum earnings`` () =
        let payment = contributoryPaymentStub(80_000.0, 8_000_000.0)
        payment.ComputePayment() |> should equal 1_500_000
        payment.WasMaxApplied |> should be True
