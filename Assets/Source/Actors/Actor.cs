﻿using Assets.Source.Actors.Characters;
using Assets.Source.Actors.Static;
using DungeonCrawl.Actors.Characters;
using DungeonCrawl.Core;
using UnityEngine;

namespace DungeonCrawl.Actors
{
    public abstract class Actor : MonoBehaviour
    {
        public (int x, int y, int z) Position
        {
            get => _position;
            set
            {
                _position = value;
                transform.position = new Vector3(value.x, value.y, value.z = Z);
            }
        }

        private (int x, int y, int z) _position;
        private SpriteRenderer _spriteRenderer;

        protected virtual void Awake()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();

            SetSprite(DefaultSpriteId);
        }

        private void Update()
        {
            OnUpdate(Time.deltaTime);
        }

        public void SetSprite(int id)
        {
            _spriteRenderer.sprite = ActorManager.Singleton.GetSprite(id);
        }

        protected virtual void TryMove(Direction direction)
        {
            var vector = direction.ToVector();
            (int x, int y, int z) targetPosition = (Position.x + vector.x, Position.y + vector.y, Position.z);
            (int x, int y, int z) currentPosition = (Position.x, Position.y, Position.z);

            var actorAtTargetPosition = ActorManager.Singleton.GetActorAt(targetPosition);
            //Debug.Log(actorAtTargetPosition);
            var playerActor = ActorManager.Singleton.GetActorAt(currentPosition);

            if (actorAtTargetPosition == null)
            {
                // No obstacle found, just move
                Position = targetPosition;
                AudioManager.PlayStepSound();
            }
            else
            {
                if (actorAtTargetPosition is Skeleton || actorAtTargetPosition is Spider)
                {
                    //playerActor.OnCollision(actorAtTargetPosition);
                    actorAtTargetPosition.OnCollision(playerActor);
                }
                else if (actorAtTargetPosition is Stairs)
                {
                    ActorManager.Singleton.DestroyAllActors();
                    MapLoader.LoadMap(2);
                }
                else if (actorAtTargetPosition is Gate)
                {
                    ActorManager.Singleton.DestroyAllActors();
                    MapLoader.LoadMap(1);
                }
                else if (actorAtTargetPosition.OnCollision(this))
                {
                    // Allowed to move
                    Position = targetPosition;
                    AudioManager.PlayStepSound();
                }
            }
        }

        /// <summary>
        ///     Invoked whenever another actor attempts to walk on the same position
        ///     this actor is placed.
        /// </summary>
        /// <param name="anotherActor"></param>
        /// <returns>true if actor can walk on this position, false if not</returns>
        public virtual bool OnCollision(Actor anotherActor)
        {
            // All actors are passable by default
            
            return true;
        }

        /// <summary>
        ///     Invoked every animation frame, can be used for movement, character logic, etc
        /// </summary>
        /// <param name="deltaTime">Time (in seconds) since the last animation frame</param>
        protected virtual void OnUpdate(float deltaTime)
        {
        }

        /// <summary>
        ///     Can this actor be detected with ActorManager.GetActorAt()? Should be false for purely cosmetic actors
        /// </summary>
        public virtual bool Detectable => true;

        /// <summary>
        ///     Z position of this Actor (0 by default)
        /// </summary>
        public virtual int Z => 0;

        /// <summary>
        ///     Id of the default sprite of this actor type
        /// </summary>
        public abstract int DefaultSpriteId { get; }

        /// <summary>
        ///     Default name assigned to this actor type
        /// </summary>
        public abstract string DefaultName { get; }
    }
}