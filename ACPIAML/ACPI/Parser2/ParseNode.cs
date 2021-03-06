using ACPIAML.Interupter;
using ACPILibs.AML;
using System.Collections.Generic;

namespace ACPILibs.Parser2
{
	public class ParseNode
	{
		public OpCode Op;
		public string Name;

		public long Start;
		public long DataStart;
		public long Length;

		public long End
		{
			get { return Start + Length + Op.CodeByteSize; }
		}

		public StackObject? ConstantValue;
		public StackObject[] Arguments;
		public List<ParseNode> Nodes = new List<ParseNode>();

		public ParseNode Parent;
		public InternalMethod Override;
		public delegate StackObject InternalMethod(ParseNode[] args);

		public ParseNode(ParseNode parent)
        {
			Parent = parent;
		}
		public override string ToString()
		{
			if (Name != null)
				return Name;
			return Op.ToString();
		}
	}
}
