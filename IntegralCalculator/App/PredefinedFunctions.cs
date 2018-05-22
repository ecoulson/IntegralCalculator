using System;
using IntegralCalculator.FunctionParser;
using IntegralCalculator.FunctionParser.EvaluationNodes;

namespace IntegralCalculator.App
{
    public class PredefinedFunctions
    {
        private static Namespace space;

        public static void addFunctionsToGlobalSpace() {
            space = Calculator.globalNameSpace;

            space.addFunction("sin", createSinFunction());
            space.addFunction("cos", createCosFunction());
            space.addFunction("tan", createTanFunction());
            space.addFunction("sec", createSecFunction());
            space.addFunction("cot", createCotFunction());
            space.addFunction("csc", createCscFunction());
            space.addFunction("arcsin", createArcsinFunction());
            space.addFunction("arccos", createArccosFunction());
            space.addFunction("arctan", createArctanFunction());
            space.addFunction("abs", createAbsFunction());
            space.addFunction("ln", createLnFunction());
            space.addFunction("log", createLogFunction());
        }

        private static Function createSinFunction() {
            Declaration declaration = new Declaration("sin(x)");
            EvaluationNode node = new SinNode();
            EvaluationTree tree = new EvaluationTree(node);
            return new Function(declaration, tree);
        }

        private static Function createCosFunction() {
            Declaration declaration = new Declaration("cos(x)");
            EvaluationNode node = new CosNode();
            EvaluationTree tree = new EvaluationTree(node);
            return new Function(declaration, tree);
        }

        private static Function createTanFunction() {
            Declaration declaration = new Declaration("tan(x)");
            EvaluationNode node = new TanNode();
            EvaluationTree tree = new EvaluationTree(node);
            return new Function(declaration, tree);
        }

        private static Function createSecFunction() {
            return new Function("sec(x)=1/cos(x)");
        }

        private static Function createCotFunction() {
            return new Function("cot(x)=1/tan(x)");
        }

        private static Function createCscFunction() {
            return new Function("csc(x)=1/sin(x)");
        }

        private static Function createAbsFunction() {
            Declaration declaration = new Declaration("abs(x)");
            EvaluationNode node = new AbsNode();
            EvaluationTree tree = new EvaluationTree(node);
            return new Function(declaration, tree);
        }

        private static Function createLnFunction() {
            Declaration declaration = new Declaration("ln(x)");
            EvaluationNode node = new LnNode();
            EvaluationTree tree = new EvaluationTree(node);
            return new Function(declaration, tree);
        }

        private static Function createLogFunction() {
            Declaration declaration = new Declaration("log(x)");
            EvaluationNode node = new LogNode();
            EvaluationTree tree = new EvaluationTree(node);
            return new Function(declaration, tree);
        }

        private static Function createArcsinFunction() {
            Declaration declaration = new Declaration("arcsin(x)");
            EvaluationNode node = new ArcsinNode();
            EvaluationTree tree = new EvaluationTree(node);
            return new Function(declaration, tree);
        }

        private static Function createArccosFunction() {
            Declaration declaration = new Declaration("arccos(x)");
            EvaluationNode node = new ArccosNode();
            EvaluationTree tree = new EvaluationTree(node);
            return new Function(declaration, tree);
        }

        private static Function createArctanFunction() {
            Declaration declaration = new Declaration("arctan(x)");
            EvaluationNode node = new ArctanNode();
            EvaluationTree tree = new EvaluationTree(node);
            return new Function(declaration, tree);
        }
    }
}
