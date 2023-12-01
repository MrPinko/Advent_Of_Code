
export class Utils {



	static ReadFileAsync = async (day: string, istest: "_test" | "" = ""): Promise<string> => {
		const filePath = `./inputs/${day}${istest}.txt`
		const decoder = new TextDecoder("utf-8");
		const data = await Deno.readFile(filePath)
		return decoder.decode(data)
	}

	static ReadLinesFromFileAsync = async (day: string, istest: "_test1" | "_test2" | "" = ""): Promise<string[]> => {
		const filePath = `./inputs/${day}${istest}.txt`
		const decoder = new TextDecoder("utf-8");
		const data = await Deno.readFile(filePath)
		return decoder.decode(data).split("\n")
	}

	static Print(res1: number, res2: number) {
		console.log("----------------------\n")
		console.log("    RESULT PART ONE   ")
		console.log(`        ${res1}       `)
		console.log("")
		console.log("----------------------")


		console.log("")
		console.log("    RESULT PART TWO   ")
		console.log(`        ${res2}       \n`)
		console.log("----------------------")
	}


}
