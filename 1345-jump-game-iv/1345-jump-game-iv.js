/**
 * @param {number[]} arr
 * @return {number}
 */
var minJumps = function(arr) {
    const targetIndex = arr.length - 1;
    if (targetIndex < 1) return 0;

    const map = new Map();
    for (let i = 0; i < arr.length; i++) {
        if (!map.has(arr[i])) map.set(arr[i], []);
        map.get(arr[i]).push(i);
    }

    let checkedIndexes = new Set();
    let stepCount = 0;
    let currentStepIndexes = new Set();
    currentStepIndexes.add(targetIndex);
    // from right to left. end to start. arr.length - 1 to 0
    while (currentStepIndexes.size > 0) {
        let nextStepIndexes = new Set();
        for (const currentStepIndex of currentStepIndexes.values()) {
            checkedIndexes.add(currentStepIndex);

            if (currentStepIndex == 0) return stepCount;
            // -1
            if (currentStepIndex > 0 && !checkedIndexes.has(currentStepIndex - 1)) {
                if ((currentStepIndex - 1) == 0) return ++stepCount;
                nextStepIndexes.add(currentStepIndex - 1);
            }
            // jumps
            const jumps = map.get(arr[currentStepIndex]);
            if (jumps) {
                map.delete(arr[currentStepIndex]);
                let limit = 0;
                for (const jumpIndex of jumps) {
                    if (jumpIndex !== currentStepIndex && !checkedIndexes.has(jumpIndex)) {
                        limit++;
                        if (limit > 5) break;
                        if (jumpIndex == 0) return ++stepCount;
                        nextStepIndexes.add(jumpIndex);
                    }
                }
            }
            // +1
            if (currentStepIndex < targetIndex && !checkedIndexes.has(currentStepIndex + 1)) {
                nextStepIndexes.add(currentStepIndex + 1);
            }
        }
        currentStepIndexes = nextStepIndexes;
        stepCount++;
    }
    return stepCount;
};