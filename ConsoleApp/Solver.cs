using Challenge.DataContracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Data;
using System.Text.RegularExpressions;

namespace ConsoleApp;

/*
 * This Solution was created by:
 * @o_0bebrik
 *   gh: @balbesi4
 * @Ghost_flick 
 *   gh: @ghost-flick
 * @snkrtree 
 *   gh: @localhoster23
 * @VartoSss 
 *   gh: @VartoSss
*/


public class Solver
{
    public static string Solve(TaskResponse taskResponse)
    {
        var question = taskResponse.Question;
        if (taskResponse.TypeId == "starter")
            return Starter.SolveStarter(question);
        else if (taskResponse.TypeId == "cypher")
            return Cypher.SolveCypher(question);
        else if (taskResponse.TypeId == "determinant")
            return Determinant.DeterminantSolver(question);
        else if (taskResponse.TypeId == "moment")
            return Moment.SolveMoment(question);
        else if (taskResponse.TypeId == "math")
            return MathSolver.Solve(question);
        else if (taskResponse.TypeId == "steganography")
            return Steganography.SolveSteganography(question);
        else if (taskResponse.TypeId == "polynomial-root")
            return PolynomialRoot.SolvePolynom(question);
        else if (taskResponse.TypeId == "statistics")
            return Statistics.SolveStatistics(question);
        else if (taskResponse.TypeId == "shape")
            return NewShape.NewShapeSolver(question);
        else if (taskResponse.TypeId == "json")
            return json.SolveCommonJSON(question);
        else if (taskResponse.TypeId == "inverse-matrix")
            return InverseMatrix.CalculateInverseMatrix(question);
        else
            throw new Exception("I don't know how to solve this task type yet");
    }
}
