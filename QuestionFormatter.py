class QuestionFormatter:
	
	import os

	def Normalizer(infile,outfile):
		
		for line in infile:
		
			txt = line.strip()
			
			if txt != '':
				
				outfile.write(line)
		
		return
		
	def Formatter(infile,outfile):
	
		counter = 1
		
		for line in infile:
		
			txt = line.strip()
			
			length = len(txt)
			
			if txt == '####':
				
				outfile.write(line)
				
			elif txt[0] == '`':
				
				counter = counter - 1
			
			elif txt[0] == 'Q':
				
				outfile.write('####\n')
			
			elif txt.endswith('?') == True:
				
				outfile.write(line)
				
			elif txt == 'Correct Response' or txt == 'Correct Answer':
				
				counter = counter - 1
			
			elif txt == 'false':
			
				z = 1
				
			elif txt == 'true':
			
				#outfile.write(line)
				z = 1
				
			elif txt == 'Incorrect Response':
				
				
				z = 1
			
			else:
			
				if counter == 0:
					
					outfile.write(line + '\n' + 'true\n')
					
					counter = 1
				
				else:
				
					outfile.write(line + '\n' + 'false\n')
		
		return
	
	ifile = open('4400QuizQuestions.txt','r')
	
	nofile = open('normfile.txt','w')
	
	Normalizer(ifile,nofile)
	
	ifile.close()
	nofile.close()
	
	nifile = open('normfile.txt','r')
	
	fofile = open('formfile.txt','w')
	
	Formatter(nifile,fofile)
	
	nifile.close()
	fofile.close()
	
	fifile = open('formfile.txt','r')
	
	ofile = open('4400QQ.txt','w')	
	
	Normalizer(fifile,ofile)
	
	fifile.close()
	ofile.close()
	
	#os.remove('formfile.txt')
	#os.remove('normfile.txt')
	