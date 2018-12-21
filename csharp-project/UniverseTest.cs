﻿using Answer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.IO;

namespace TechIo
{
    [TestClass]
    public class UniverseTest
    {
	private bool shouldShowHint = false;
	[TestMethod]
	public void VerifyCountAllStars() 
	{
		shouldShowHint = true;
		Assert.AreEqual (6,   UniverseStub.CountAllStars (1, 2, 3));
		Assert.AreEqual (16,   UniverseStub.CountAllStars (10, 3, 2, 1));
		Assert.AreEqual (42,   UniverseStub.CountAllStars (20, 20, 2));
		shouldShowHint = false;
	}

	[TestCleanup()]
      	public void Cleanup()
      	{		
		if(shouldShowHint)
		{	
			// On Failure
			PrintMessage("Hint 💡", "Did you properly accumulate all stars into 'totalStars'? 🤔");
		} 
		else
		{
 			// On success
			if(ExistsInFile(@"/project/target/Exercises/UniverseStub.cs", "galaxies.Sum();")) 
			{
				PrintMessage("My personal Yoda, you are. 🙏", "* ● ¸ .　¸. :° ☾ ° 　¸. ● ¸ .　　¸.　:. • ");
				PrintMessage("My personal Yoda, you are. 🙏", "           　★ °  ☆ ¸. ¸ 　★　 :.　 .   ");
				PrintMessage("My personal Yoda, you are. 🙏", "__.-._     ° . .　　　　.　☾ ° 　. *   ¸ .");
				PrintMessage("My personal Yoda, you are. 🙏", "'-._\\7'      .　　° ☾  ° 　¸.☆  ● .　　　");
				PrintMessage("My personal Yoda, you are. 🙏", " /'.-c    　   * ●  ¸.　　°     ° 　¸.    ");
				PrintMessage("My personal Yoda, you are. 🙏", " |  /T      　　°     ° 　¸.     ¸ .　　  ");
				PrintMessage("My personal Yoda, you are. 🙏", "_)_/LI");
			} else {
				PrintMessage("Kudos 🌟", "Using Linq, your code could have been shorter. Try it!");
				PrintMessage("Kudos 🌟", "");
				PrintMessage("Kudos 🌟", "int[] galaxies = {37, 3, 2};");
				PrintMessage("Kudos 🌟", "int totalStars = galaxies.Sum(); // 42");
			}	
		}
      	}


	/****
		TOOLS
	*****/
	// Display a custom message in a custom channel
	private static void PrintMessage(String channel, String message)
	{		
		Console.WriteLine ($"TECHIO> message --channel \"{channel}\" \"{message}\"");
	}
	// You can manually handle the success/failure of a testcase using this function
	private static void Success(Boolean success)
	{
		Console.WriteLine($"TECHIO> success {success}");
	}
	// Check the user code looking for a keyword
	private static Boolean ExistsInFile(String path, String keyword) 
	{
		return File.ReadAllText(path).Contains(keyword);
	}
    }
}
