actionResults = [[-2, 4, -1], [10, 2, -1], [0, -1, 6]]
actionNames = ["play", "feed", "clean"]
state = [0, 0, 0]
mood = "happy"
moodStates = ["happy", "ecstatic", "sad"]
actions = []
happyRatio = (2.0, 2.5)
ecstaticCriteria = [72, 30, 0]
actionPlan = []

maxMoves = 20
moves = 0
attempt = 0

def isHappy () :
  global actions
  p = 0
  f = 0
  for i in actions :
    if i == actionNames[0] :
      p += 1
    elif i == actionNames[1] :
      f += 1
  
  ratio = 0
  if (p != 0) :
    ratio = f / p

  if (2.0 <= ratio and ratio <= 2.5) :
    return True
  return False

def isEcstatic (currentState) :
  global ecstaticCriteria;
  for i in range(3) :
    if currentState[i] != ecstaticCriteria[i] :
      return False
  return isHappy() and True

def adjustState (currentState, stateChange) :
  for i in range(3) :
    currentState[i] += stateChange[i]

def heuristic(currentState, targetState) :
  h = 0
  for i in range(3) :
    h += abs(targetState[i] - currentState[i])
  return h

def simulateMove(currentState, move) :
  simulation = [currentState[0], currentState[1], currentState[2]]
  for i in range(3) :
    simulation[i] += move[i]
  return simulation

actionPlan = [0] * maxMoves 
while mood != moodStates[1] :
  if (moves >= maxMoves) :
    break

  # find the best move
  bestmove = 0
  hvalues = []
  for i in range(3) :
    hvalues.append(heuristic(simulateMove(state, actionResults[i]), ecstaticCriteria))
  bestmove = hvalues.index(min(hvalues))

  # Peform Action
  actions.append(actionNames[bestmove])
  adjustState(state, actionResults[bestmove])

  # Check mood
  if (isHappy()) :
    if (isEcstatic(state)) :
      mood = moodStates[1]
    else :
      mood = moodStates[0]
  else :
    mood = moodStates[2]

  moves += 1

if mood == moodStates[1] :
  print("Solution found:", str(actions))
  print("Final state:", str(state))
  print("Final mood:", mood)  

else :
  print("Failed to find a solution in", maxMoves, "moves")
  print("Final state:", str(state))
  print("Final mood:", mood)