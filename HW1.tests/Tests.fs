namespace HW1.tests

open System
open Microsoft.VisualStudio.TestTools.UnitTesting

[<TestClass>]
type TestClass () =

  let filename = "myinfo.csv"
  let lines = IO.File.ReadLines filename |> Seq.toArray

  [<TestMethod>]
  member __.``Does your CSV file have just two lines?``() =
    Assert.AreEqual (2, Array.length lines)

  [<TestMethod>]
  member __.``Does your CSV file has the correct header?``() =
    let expected = "student_id,email,github_id"
    Assert.AreEqual (expected, lines.[0])

  [<TestMethod>]
  member __.``Does your CSV file contain a valid student ID?``() =
    let studentID = lines.[1].Split(',').[0] |> Convert.ToUInt64
    Assert.IsTrue (studentID > 0UL)

  [<TestMethod>]
  member __.``Does your CSV file contain a valid email?``() =
    let email = lines.[1].Split(',').[1]
    let emailID = email.Split('@').[0]
    let emailDomain = email.Split('@').[1]
    Assert.IsTrue (email.Contains ("@"))
    Assert.IsTrue (String.length emailID > 0)
    Assert.IsTrue (String.length emailDomain > 0)

  [<TestMethod>]
  member __.``Does your CSV file contain a valid github ID?``() =
    let gitid = lines.[1].Split(',').[2]
    Assert.IsTrue (String.length gitid > 0)
