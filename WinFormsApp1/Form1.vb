Option Explicit On
Public Class Form1
    ' Define Constants
    Const r As Double = 100          ' Maximum damage rate (scaling factor)
    Const k As Double = 0.4         ' Sensitivity factor (controls how fast damage escalates)
    Const t_0 As Double = 42        ' Threshold time before damage begins to show
    Const alpha As Double = 2       ' Synergy coefficient for B12 and Omega-3 deficiencies
    Const max_damage As Double = 100 ' Maximum possible damage (for scaling)

    ' Deficiency levels (calculated) citation references:
    ' https://pmc.ncbi.nlm.nih.gov/articles/PMC8746448/
    ' https://pmc.ncbi.nlm.nih.gov/articles/PMC9320578/
    Const b12_deficiency As Double = 0.167    ' 16.7% B12 deficiency given the required daily intake of 2.4 mcg to the average vegan intake of 0.4 mcg
    Const omega3_deficiency As Double = 0.0068 ' 0.68% Omega-3 deficiency given the required daily intake of 1.1g to the average vegan intake of 7.3mg

    ' Function to calculate Neurological Damage at time t
    Function CalculateDamage(t As Double) As Double
        Const r As Double = 537
        Const k As Double = 0.00025
        Const t_0 As Double = 42
        Const max_damage As Double = 100

        Dim sigmoid As Double
        sigmoid = 1 / (1 + Math.Exp(-k * (t - t_0)))

        Dim combinedDeficiency As Double
        combinedDeficiency = 0.1731

        CalculateDamage = r * combinedDeficiency * sigmoid

        If CalculateDamage > 93 Then
            CalculateDamage = 93
        End If
    End Function

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim time As Double
        Dim damage As Double

        ' Input time (days)
        time = DateDiff("d", DatePicker1.Value, DateAndTime.Today)

        ' Calculate damage at time t
        damage = CalculateDamage(time)

        ' Output the damage
        Label2.Text = "Neurological damage at " & time & " days: " & damage & "% damage"
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim time As Double
        Dim damage As Double

        ' Input time (days)
        time = 29200 ' approx. 80 years in days, the average human lifespan.

        ' Calculate damage at time t
        damage = CalculateDamage(time)

        ' Output the damage
        Label2.Text = "Neurological damage at " & time & " days: " & damage & "% damage"
    End Sub
End Class
