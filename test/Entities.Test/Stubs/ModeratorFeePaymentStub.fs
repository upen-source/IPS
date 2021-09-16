namespace Entities.Test

open System
open Entities

module ModeratorFeePaymentStub =

    let contributoryPaymentStub (servicePrice: float, patientEarnings: float) : ContributoryPayment =
        let patient = Patient("123", patientEarnings)
        ContributoryPayment("123", DateTime.Now, servicePrice, patient)
